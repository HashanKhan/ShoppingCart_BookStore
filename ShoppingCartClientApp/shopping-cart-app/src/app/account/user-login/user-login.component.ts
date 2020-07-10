import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserCredentials } from '../models/userCredentials';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

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

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
  });

  //For easy testing purposes.
  this.onTesting();
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

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

            var obj_token = Object.values(res.token);
            var token_string = JSON.stringify(obj_token);

            localStorage.setItem('auth_token', token_string);
            localStorage.setItem('logged_userName', res.customer.userName);
            localStorage.setItem('user_password', res.customer.password);

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

  onTesting(){
    this.loginForm.setValue({
      username: "user100",
      password: "12345678"
    });
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1500,
    });
  }

  onReset(){
    this.submitted = false;
    this.loginForm.reset();
  }

}
