import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { StateTree } from '../dependencies/models/stateTree';
import { PaymentDetails } from '../dependencies/models/paymentDetails';
import { PaymentService } from '../dependencies/services/payment.service';
import { UserRegistrationComponent } from 'src/app/account/user-registration/user-registration.component';
import { AuthenticationService } from 'src/app/account/dependencies/services/authentication.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PaymentMethods } from '../dependencies/models/paymentMethods';

@Component({
  selector: 'app-payment-confirmation-modal',
  templateUrl: './payment-confirmation-modal.component.html',
  styleUrls: ['./payment-confirmation-modal.component.css']
})
export class PaymentConfirmationModalComponent implements OnInit {
  state: StateTree;
  paymentMethod: PaymentMethods;

  payments: PaymentMethods[] = [
    {
      name: 'Visa',
      image: '/assets/project_images/payment_images/VisaCreditCard.JPG'
    },
    {
      name: 'Mastercard',
      image: '/assets/project_images/payment_images/MasterCreditCard.JPG'
    },
    {
      name: 'Paypal',
      image: '/assets/project_images/payment_images/Paypal.JPG'
    }
  ];

  paymentDetails: PaymentDetails;

  constructor(@Inject(MAT_DIALOG_DATA) public data: StateTree, private paymentService: PaymentService, private registration: UserRegistrationComponent,
              private authenticationService: AuthenticationService, private snackBar: MatSnackBar, public dialogRef: MatDialogRef<PaymentConfirmationModalComponent>) {
    this.state = data; 
  }

  ngOnInit(): void {
  }

  //Submit Payment.
  onSubmit(){
    this.paymentDetails = {
      cart: this.state.cart,
      total: this.state.tot.totl,
      paymentMethod: this.paymentMethod.name,
      date: this.registration.dateTime(),
      customerUserName: this.authenticationService.getUserName()
    }

    this.paymentService.completePayment(this.paymentDetails).subscribe(res => {
        if(res){
            this.openSnackBar(res,"Purchased.");

            this.dialogRef.close();

            location.reload(true);
        }
        else{
          console.log("Error.");
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
