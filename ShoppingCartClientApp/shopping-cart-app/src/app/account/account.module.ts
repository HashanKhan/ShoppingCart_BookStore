import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';

import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { UserLoginComponent } from './user-login/user-login.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderDetailsModalComponent } from './order-details-modal/order-details-modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { PaymentListComponent } from './payment-list/payment-list.component';


@NgModule({
  declarations: [UserRegistrationComponent, UserLoginComponent, OrderListComponent, OrderDetailsModalComponent, PaymentListComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatPaginatorModule,
    MatIconModule,
    MatTableModule,
    FormsModule,
    MatDialogModule
  ]
})
export class AccountModule { }
