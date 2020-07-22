import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject, Subject, merge, throwError } from 'rxjs';
import { Books } from '../models/books';
import { StateTree } from '../models/stateTree';
import { scan, startWith, map, tap, combineLatest, switchMap, shareReplay, debounceTime, catchError } from 'rxjs/operators';
import { v4 as uuid } from 'uuid';
import { CartItem } from '../models/CartItem';
import { MatDialog } from '@angular/material/dialog';
import { PaymentConfirmationModalComponent } from '../../payment-confirmation-modal/payment-confirmation-modal.component';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  apiUrl: string;

  stateTree = new BehaviorSubject<StateTree>(null);
  checkoutTrigger = new BehaviorSubject<boolean>(false);
  cartAdd = new Subject<CartItem>();
  cartRemove = new Subject<CartItem>();

  //The uuid package will be used to assign random ids for the items in the cart.
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

  //Creating the state of the shopping cart, store, total amount and checkout.
  state: Observable<StateTree> = this.stateTree.pipe(
    switchMap(() => this.getBooks().pipe(
      combineLatest([this.cartItems, this.totalAmount, this.checkoutTrigger]),
      debounceTime(0),
    )),
    map(([store, cart, tot, checkout]: any) => ({ store, cart, tot, checkout })),
    tap(state => {
      if (state.checkout) {
        this.checkStockAvailability(state.cart).subscribe(res => {
          if(res == "Order is OK."){
            this.dialog.closeAll();
            this.openPaymentModal(state);
            this.checkoutTrigger.next(false);
          }
          else{
            this.checkoutTrigger.next(false);
            sessionStorage.setItem('error_res', res);
          }
        });
      }
    }),
    //Just sharing only for the App.
    shareReplay(1)
  );

  constructor(private http: HttpClient, public dialog: MatDialog) {
    this.apiUrl = environment.BaseUrl;
  }

  // Get all books method.
  getBooks(): Observable<Books[]>{
    return this.http.get<Books[]>(this.apiUrl + "products");
  }

  // Add books to cart method.
  addCartItem(item: CartItem) {
    this.cartAdd.next({ ...item, uuid: uuid() });
  }

  // Remove books from cart method.
  removeCartItem(item: CartItem) {
    this.cartRemove.next({ ...item, remove: true });
  }

  // Trigger the checkout.
  checkout() {
    this.checkoutTrigger.next(true);
  }

  //Check availability of the stock againts the number of items in the cart.
  checkStockAvailability(cart: CartItem[]): Observable<string>{
    return this.http.post(this.apiUrl + "products/" + "checkAvailability", cart, {responseType: 'text'}
    ).pipe(
      catchError(this.handleError)
    );
  }

  // Open Payment Modal method.
  openPaymentModal(state: StateTree){
    const dialogRef = this.dialog.open(PaymentConfirmationModalComponent, {
      width: '600px',
      height: '405px',
      disableClose: true,
      data: state
    });

    dialogRef.afterOpened().subscribe(removeErrorResponse => {
      removeErrorResponse = sessionStorage.removeItem('error_res');
    });
  }

  // Retrieving error response mrthod.
  getErrorResponse(){
    return sessionStorage.getItem('error_res');
  }

  // Error handler.
private handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
    console.error('An error occurred:', error.error.message);
  } 
  else {
    console.error(
      `Backend returned code ${error.status}, ` +
      `body was: ${error.error}`);
  }
  return throwError(
    'Something bad happened; please try again later.');
};
}
