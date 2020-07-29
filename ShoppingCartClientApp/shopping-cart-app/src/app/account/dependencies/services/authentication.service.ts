import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AccountService } from './account.service';
import { UserCredentials } from '../models/userCredentials';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  userCredentials: UserCredentials;

  constructor(private router: Router, private snackBar: MatSnackBar, private accountService: AccountService) { }

  //Get stored token.
  getToken() {
    return localStorage.getItem('auth_token');
  }

  //Get stored username.
  getUserName(){
    return localStorage.getItem('logged_userName');
  }

  //Get stored password.
  getPassword(){
    return localStorage.getItem('user_password');
  }

  //Get stored Name.
  getCustomerName(){
    return localStorage.getItem('customer_name');
  }

  //Check whether the user is logged or not.
  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('auth_token');
    return (authToken !== null) ? true : false;
  }

  //Customer LogOut method Implemetation.
  onLogout() {
    let userName = this.getUserName();
    let password = this.getPassword();

    this.userCredentials = {
      userName: userName,
      password: password
    }

    this.accountService.logOutCustomer(this.userCredentials).subscribe(res => {
      if(res){
        if(res == "You have been Logged Out Successfully."){

          let removeToken = localStorage.removeItem('auth_token');
          let removeUser = localStorage.removeItem('logged_userName');
          let removePassword = localStorage.removeItem('user_password');
          let removeName = localStorage.removeItem('customer_name');

          if (removeToken == null && removeUser == null && removePassword == null && removeName == null) {
            this.openSnackBar(res,"Logged Out");
            location.reload(true);    
          }
        }
        else{
          this.openSnackBar(res,"Log In First");
          this.router.navigate(['/account/login']);
        }
      }
      else{
        console.log("Error");
      }
    });
  }

  //Snackbar notification method.
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1500,
    });
  }
}
