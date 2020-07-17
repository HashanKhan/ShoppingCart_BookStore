import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';

import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { UserLoginComponent } from './user-login/user-login.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './dependencies/helpers/TokenInterceptor';
import { ErrorInterceptor } from './dependencies/helpers/ErrorInterceptor';


@NgModule({
  declarations: [UserRegistrationComponent, UserLoginComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatSnackBarModule
  ],
  providers: []
})
export class AccountModule { }
