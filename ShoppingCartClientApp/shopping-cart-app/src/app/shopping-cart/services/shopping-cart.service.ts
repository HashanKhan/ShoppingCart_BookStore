import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Books } from '../models/books';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.BaseUrl;
  }

  getBooks(): Observable<Books[]>{
    return this.http.get<Books[]>(this.apiUrl + "products");
  }
}
