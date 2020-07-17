import { Component, OnInit, Inject } from '@angular/core';
import { ShoppingCartService } from '../dependencies/services/shopping-cart.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StateTree } from '../dependencies/models/stateTree';

@Component({
  selector: 'app-payment-confirmation-modal',
  templateUrl: './payment-confirmation-modal.component.html',
  styleUrls: ['./payment-confirmation-modal.component.css']
})
export class PaymentConfirmationModalComponent implements OnInit {
  // state = this.shoppingCartService.state.pipe();
  state: StateTree;

  constructor(@Inject(MAT_DIALOG_DATA) public data: StateTree) {
    this.state = data; 
    console.log(this.state.tot);
  }

  ngOnInit(): void {
  }

}
