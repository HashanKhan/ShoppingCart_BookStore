import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { CartItem } from '../models/CartItem';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  @Input() state: any;

  constructor(private shoppingCartService: ShoppingCartService) { }

  ngOnInit(): void {
  }

  //Remove Items from Cart
  removeItemsFromCart(item: CartItem): void {
    this.shoppingCartService.removeCartItem(item);
  }

}
