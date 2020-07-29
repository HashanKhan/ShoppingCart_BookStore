import { Component } from '@angular/core';
import { AuthenticationService } from './account/dependencies/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'shopping-cart-app';

  constructor(public authenticationService: AuthenticationService) {}

   ngOnInit(): void {}

  //LogOut Method 
  onLogOut(){
    this.authenticationService.onLogout();
  }
}
