import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-check-out-modal',
  templateUrl: './check-out-modal.component.html',
  styleUrls: ['./check-out-modal.component.css']
})
export class CheckOutModalComponent implements OnInit {
  state = this.shoppingCartService.state.pipe();

  constructor(private shoppingCartService: ShoppingCartService) { }

  ngOnInit(): void {
  }

  confirmOrder(){
    
  }

}
