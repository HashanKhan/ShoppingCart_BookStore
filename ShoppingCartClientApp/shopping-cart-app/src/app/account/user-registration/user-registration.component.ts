import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Customers } from '../dependencies/models/customers';
import { AccountService } from '../dependencies/services/account.service';
import { MustMatch } from '../dependencies/helpers/must-match.validator';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  phonePattern = '^[0-9]*$';
  emailPattern = '^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$';
  namePattern = '^[A-Za-z0-9]*$';

  customer: Customers;
  response: string;
  
  //Setting date in the correct format before submitting.   
   dateTime() {
    var datenow = new Date(Date.now());
    var y = datenow.getFullYear();
    var m = datenow.getMonth() + 1;
    var d = datenow.getDate();

    var mm = m < 10 ? '0' + m : m;
    var dd = d < 10 ? '0' + d : d;
    
    return [y,mm,dd].join('-');
  }

  currentDate : string = this.dateTime();

  constructor(private formBuilder: FormBuilder, private accountService: AccountService, private snackBar: MatSnackBar,
                                    private router: Router) {}

  //Set form validations at the startup.                                  
  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.pattern(this.namePattern)]],
      phone: ['', [Validators.minLength(10), Validators.pattern(this.phonePattern), Validators.maxLength(10)]],
      email: ['', [Validators.required, Validators.pattern(this.emailPattern)]],
      address: ['', Validators.required],
      username: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(10)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(15)]],
      confirmPassword: ['', Validators.required]
  }, {
      validator: MustMatch('password', 'confirmPassword')
  });

  //For easy testing purposes.
  this.onTesting();

  }

  //convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  //Submit user login request method.
  onSubmit(){
    this.submitted = true;

    this.customer = {
      id: 0,
      name: this.registerForm.controls['name'].value,
      phone: this.registerForm.controls['phone'].value,
      email: this.registerForm.controls['email'].value,
      address: this.registerForm.controls['address'].value,
      userName: this.registerForm.controls['username'].value,
      password: this.registerForm.controls['password'].value,
      loginStatus: false,
      registerDate: this.currentDate
    }

    this.accountService.registerCustomer(this.customer).subscribe(res => {
      if(res){
        if(res == "Added Successfully."){
          this.response = "";

          this.openSnackBar(res,"Registered");

          this.router.navigate(['/account/login']);  
        }
        else{
          this.response = res;
        }  
      }
      else{
        console.log("Error");
      }
    });

  }

  //Sets testing data to the form values for easy testing when page loads.
  onTesting(){
    this.registerForm.setValue({
      name: "TestUser",
      phone: "1234567890",
      email: "testuser@gmail.com",
      address: "Colombo",
      username: "user100",
      password: "12345678",
      confirmPassword: "12345678"
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
    this.registerForm.reset();
  }

}
