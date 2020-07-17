import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../dependencies/services/shopping-cart.service';
import { AuthenticationService } from 'src/app/account/dependencies/services/authentication.service';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-check-out-modal',
  templateUrl: './check-out-modal.component.html',
  styleUrls: ['./check-out-modal.component.css']
})
export class CheckOutModalComponent implements OnInit {
  state = this.shoppingCartService.state.pipe();
  response: string;

  constructor(public shoppingCartService: ShoppingCartService, public authenticationService: AuthenticationService,
    public dialogRef: MatDialogRef<CheckOutModalComponent>, private router: Router) { }

  ngOnInit(): void {
  }

  confirmOrder(){
    this.shoppingCartService.checkout();
  }

  navigateToLogin(){
    this.dialogRef.close();
    this.router.navigate(['/account/login']);
  }
}
