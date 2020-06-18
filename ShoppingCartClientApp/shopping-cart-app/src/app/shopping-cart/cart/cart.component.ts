import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { CartItem } from '../models/CartItem';
import { CheckOutModalComponent } from '../check-out-modal/check-out-modal.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  @Input() state: any;

  constructor(private shoppingCartService: ShoppingCartService, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  //Remove Items from Cart
  removeItemsFromCart(item: CartItem): void {
    this.shoppingCartService.removeCartItem(item);
  }

  openCheckoutModal(){
    const dialogRef = this.dialog.open(CheckOutModalComponent, {
      width: '600px',
      height: '400px',
      disableClose: true,
    });
  }

}
