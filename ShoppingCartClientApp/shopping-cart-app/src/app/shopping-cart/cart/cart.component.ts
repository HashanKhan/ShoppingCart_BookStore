import { Component, OnInit, Input } from '@angular/core';
import { CheckOutModalComponent } from '../check-out-modal/check-out-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { ShoppingCartService } from '../dependencies/services/shopping-cart.service';
import { CartItem } from '../dependencies/models/CartItem';

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

  //Open a pop-up for the Checkout.
  openCheckoutModal(){
    const dialogRef = this.dialog.open(CheckOutModalComponent, {
      width: '600px',
      height: '500px',
      disableClose: true,
    });

    dialogRef.afterClosed().subscribe(removeErrorResponse => {
      removeErrorResponse = sessionStorage.removeItem('error_res');
    });
  }

}
