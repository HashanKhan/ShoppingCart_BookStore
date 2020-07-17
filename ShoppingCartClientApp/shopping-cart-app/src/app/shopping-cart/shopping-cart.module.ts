import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShoppingCartRoutingModule } from './shopping-cart-routing.module';
import { BookListComponent } from './book-list/book-list.component';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CartComponent } from './cart/cart.component';
import {MatDividerModule} from '@angular/material/divider';
import {MatChipsModule} from '@angular/material/chips';
import { CheckOutModalComponent } from './check-out-modal/check-out-modal.component';
import {MatDialogModule} from '@angular/material/dialog';
import { PaymentConfirmationModalComponent } from './payment-confirmation-modal/payment-confirmation-modal.component';


@NgModule({
  declarations: [BookListComponent, CartComponent, CheckOutModalComponent, PaymentConfirmationModalComponent],
  imports: [
    CommonModule,
    ShoppingCartRoutingModule,
    MatCardModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    HttpClientModule,
    MatDividerModule,
    MatChipsModule,
    MatDialogModule
  ]
})
export class ShoppingCartModule { }
