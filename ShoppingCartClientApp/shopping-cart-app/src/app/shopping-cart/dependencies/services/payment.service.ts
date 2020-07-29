import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';
import { PaymentDetails } from '../models/paymentDetails';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.BaseUrl;
  }

  //Complete payment and purchase items.
  completePayment(paymentDetails: PaymentDetails): Observable<string>{
    return this.http.post(this.apiUrl + "payments/", paymentDetails, {responseType: 'text'}
    ).pipe(
      catchError(this.handleError)
    );
  }

  //Error handler.
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
