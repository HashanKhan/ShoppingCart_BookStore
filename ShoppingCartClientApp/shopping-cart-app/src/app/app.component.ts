import { Component } from '@angular/core';
import { AuthenticationService } from './account/services/authentication.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'shopping-cart-app';
  userName: string = '';

  constructor(public authenticationService: AuthenticationService) {}

   ngOnInit(): void {
    this.userName = this.authenticationService.getUserName();
   }

  onLogOut(){
    this.authenticationService.onLogout();
  }
}
