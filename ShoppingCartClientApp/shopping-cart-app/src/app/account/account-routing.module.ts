import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { AuthGuard } from './dependencies/helpers/auth-guard';
import { OrderListComponent } from './order-list/order-list.component';
import { PaymentListComponent } from './payment-list/payment-list.component';

//Routes under the Account module.
const routes: Routes = [
  { path: 'register', component: UserRegistrationComponent },
  { path: 'login', component: UserLoginComponent },
  { path: 'orders', component: OrderListComponent, canActivate: [AuthGuard] },
  { path: 'payments', component: PaymentListComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
