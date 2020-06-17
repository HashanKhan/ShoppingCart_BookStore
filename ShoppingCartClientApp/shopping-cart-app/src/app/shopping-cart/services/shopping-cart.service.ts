import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject, Subject, merge } from 'rxjs';
import { Books } from '../models/books';
import { StateTree } from '../models/stateTree';
import { scan, startWith, map, tap, combineLatest, switchMap, shareReplay, debounceTime } from 'rxjs/operators';
import { v4 as uuid } from 'uuid';
import { CartItem } from '../models/CartItem';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  apiUrl: string;

  stateTree = new BehaviorSubject<StateTree>(null);
  checkoutTrigger = new BehaviorSubject<boolean>(false);
  cartAdd = new Subject<CartItem>();
  cartRemove = new Subject<CartItem>();

  //Scan the shopping cart for bookItems.
  private get cartItems(): Observable<CartItem[]> {
    return merge(this.cartAdd, this.cartRemove).pipe(
      startWith([]),
      scan((acc: CartItem[], item: CartItem) => {
        if (item) {
          if (item.remove) {
            return [...acc.filter(i => i.uuid !== item.uuid)];
          }
          return [...acc, item];
        }
      })
    );
  }

  //Get the Total value.
  private get totalAmount(): Observable<any> {
    return this.cartItems.pipe(
      map(items => {
        let total = 0;
        for (const i of items) {
          total += i.price;
        }
        return total;
      }),
      map(cost => ({
        totl: cost
      })
      )
    );
  }

  //Creating the state of the shopping cart
  state: Observable<StateTree> = this.stateTree.pipe(
    switchMap(() => this.getBooks().pipe(
      combineLatest([this.cartItems, this.totalAmount, this.checkoutTrigger]),
      debounceTime(0),
    )),
    map(([store, cart, tot, checkout]: any) => ({ store, cart, tot, checkout })),
    tap(state => {
      if (state.checkout) {
        console.log('checkout', state);
      }
    }),
    //Just sharing only for the App.
    shareReplay(1)
  );

  constructor(private http: HttpClient) {
    this.apiUrl = environment.BaseUrl;
  }

  getBooks(): Observable<Books[]>{
    return this.http.get<Books[]>(this.apiUrl + "products");
  }

  addCartItem(item: CartItem) {
    this.cartAdd.next({ ...item, uuid: uuid() });
  }

  removeCartItem(item: CartItem) {
    this.cartRemove.next({ ...item, remove: true });
  }
}
