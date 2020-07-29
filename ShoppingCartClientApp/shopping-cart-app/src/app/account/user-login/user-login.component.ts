import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserCredentials } from '../dependencies/models/userCredentials';
import { AccountService } from '../dependencies/services/account.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;

  userCredentials: UserCredentials;
  response: string;

  constructor(private formBuilder: FormBuilder, private accountService: AccountService, private router: Router,
                                    private snackBar: MatSnackBar) { }

  //Set form validations at the startup.                                  
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
  });

  //For easy testing purposes.
  this.onTesting();
  }

  //convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  //Submit user Login request.
  onSubmit(){
    this.submitted = true;

    this.userCredentials = {
      userName: this.loginForm.controls['username'].value,
      password: this.loginForm.controls['password'].value,
    }

    this.accountService.loginCustomer(this.userCredentials).subscribe(res => {
        if(res){
          if(res.message == "Logged in Successfully."){
            this.response = "";

            localStorage.setItem('auth_token', res.token.token);
            localStorage.setItem('logged_userName', res.customer.userName);
            localStorage.setItem('user_password', res.customer.password);
            localStorage.setItem('customer_name', res.customer.name);

            this.openSnackBar(res.message,"Logged IN");

            this.router.navigate(['/shoppingCart/books']);
          }
          else{
            this.loginForm.controls['password'].reset();

            this.response = res.message;
          }
        }
        else{
          console.log("Error.");
        }
    });
  }

  //Sets testing data to the form values for easy testing when page loads.
  onTesting(){
    this.loginForm.setValue({
      username: "hash123",
      password: "12345678"
    });
  }

  //Snackbar notification method.
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1500,
    });
  }

  //Reset the form values method.
  onReset(){
    this.submitted = false;
    this.loginForm.reset();
  }

}
