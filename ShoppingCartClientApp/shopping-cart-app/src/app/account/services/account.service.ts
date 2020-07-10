import { Injectable } from '@angular/core';
import { Customers } from '../models/customers';
import { Observable, throwError,  } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, tap } from 'rxjs/operators';
import { UserCredentials } from '../models/userCredentials';
import { TokenResponse } from '../models/tokenResponse';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  apiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token',
    })
  };

  constructor(private http: HttpClient) { 
    this.apiUrl = environment.BaseUrl;
  }

registerCustomer(customer: Customers): Observable<string> {
  return this.http.post(this.apiUrl + "accounts/" + "register", customer, {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token',
    }),
    responseType: 'text'
  })
    .pipe(
      catchError(this.handleError)
    );
}

loginCustomer(userCredentials: UserCredentials): Observable<TokenResponse> {
  return this.http.post<TokenResponse>(this.apiUrl + "login/" + "login", userCredentials)
  .pipe(catchError(this.handleError)
  );
}

logOutCustomer(userCredentials: UserCredentials): Observable<string> {
  return this.http.post(this.apiUrl + "accounts/" + "logout", userCredentials, {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token',
    }),
    responseType: 'text'
  })
    .pipe(
      catchError(this.handleError)
    );
}

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
