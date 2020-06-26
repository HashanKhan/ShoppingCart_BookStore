import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MustMatch } from '../helpers/must-match.validator';
import { Customers } from '../models/customers';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  phoneNumber = '^[0-9]*$';
  emailPattern = '^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$';
  namePattern = '[a-zA-Z ]*';

  customer: Customers;

  //Current Date and Time
  currentDate = new Date().toString();

  constructor(private formBuilder: FormBuilder, private accountService: AccountService) {}

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.pattern(this.namePattern)]],
      phone: ['', [Validators.minLength(10), Validators.pattern(this.phoneNumber), Validators.maxLength(10)]],
      email: ['', [Validators.required, Validators.pattern(this.emailPattern)]],
      address: ['', Validators.required],
      username: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(10)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(15)]],
      confirmPassword: ['', Validators.required]
  }, {
      validator: MustMatch('password', 'confirmPassword')
  });

  //For easy testing purposes.
  this.registerForm.setValue({
    name: "TestUser",
    phone: 1234567890,
    email: "testuser@gmail.com",
    address: "Colombo",
    username: "user101",
    password: "12345678",
    confirmPassword: "12345678"
  });
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit(){
    this.submitted = true;

    this.customer = {
      id: null,
      name: this.registerForm.controls['name'].value,
      phone: this.registerForm.controls['phone'].value,
      email: this.registerForm.controls['email'].value,
      address: this.registerForm.controls['address'].value,
      userName: this.registerForm.controls['username'].value,
      password: this.registerForm.controls['password'].value,
      loginStatus: false,
      registerDate: this.currentDate
    }

    console.log("DETAILS", this.customer);

    //Need to implement the email already existed or not part here later.

    // this.accountService.registerCustomer(this.customer).subscribe(res => {
    //   if(res){
    //     //Need to complete after the API is ready.
    //   }
    //   else{
    //     //Need to complete after the API is ready.
    //   }
    // });

  }

  onReset(){
    this.submitted = false;
    this.registerForm.reset();
  }

}
