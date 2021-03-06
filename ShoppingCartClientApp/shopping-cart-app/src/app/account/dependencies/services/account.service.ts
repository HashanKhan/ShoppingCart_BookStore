import { Injectable } from '@angular/core';
import { Customers } from '../models/customers';
import { Observable, throwError,  } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { UserCredentials } from '../models/userCredentials';
import { TokenResponse } from '../models/tokenResponse';
import { Orders } from '../models/orders';
import { ItemDetails } from '../models/itemDetails';
import { Payments } from '../models/payments';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  apiUrl: string;

  constructor(private http: HttpClient) { 
    this.apiUrl = environment.BaseUrl;
  }

//Customer registration method.  
registerCustomer(customer: Customers): Observable<string> {
  return this.http.post(this.apiUrl + "accounts/" + "register", customer, {responseType: 'text'}
  ).pipe(
      catchError(this.handleError)
  );
}

//Customer login method.
loginCustomer(userCredentials: UserCredentials): Observable<TokenResponse> {
  return this.http.post<TokenResponse>(this.apiUrl + "accounts/" + "login", userCredentials)
  .pipe(catchError(this.handleError)
  );
}

//Customer logout method.
logOutCustomer(userCredentials: UserCredentials): Observable<string> {
  return this.http.post(this.apiUrl + "accounts/" + "logout", userCredentials, {responseType: 'text'}
  ).pipe(
      catchError(this.handleError)
  );
}

//Get Orders method.
getOrders(userCredentials: UserCredentials): Observable<Orders[]>{
  return this.http.post<Orders[]>(this.apiUrl + "accounts/" + "orders", userCredentials)
  .pipe(
      catchError(this.handleError)
  );
}

//Get OrderDetails method.
getOrderDetails(order: Orders): Observable<ItemDetails[]>{
  return this.http.post<ItemDetails[]>(this.apiUrl + "accounts/" + "orderDetails", order)
  .pipe(
      catchError(this.handleError)
  );
}

//Get Payments method.
getPayments(userCredentials: UserCredentials): Observable<Payments[]>{
  return this.http.post<Payments[]>(this.apiUrl + "accounts/" + "payments", userCredentials)
  .pipe(
      catchError(this.handleError)
  );
}

// Error handler.
private handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
    console.error('An error occurred:', error.error.message);
  } 
  else {
    console.error(
      `Backend returned code ${error.status}, ` +
      `body was: ${error.error}`);
  }
  return throwError(
    'Something bad happened; please try again later.');
};
}
