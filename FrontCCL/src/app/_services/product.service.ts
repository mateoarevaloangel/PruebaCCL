import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../interfaces/product';
import { SendProduct } from '../interfaces/send-product';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

constructor(private http: HttpClient) {}
  isLoggedIn: boolean = false;
  private baseUrl: string = "https://localhost:7213/api/";//appsettings.apiUrl;

  /*GetAllProducts(): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}Auth/login`)
  }*/

  list() : Observable<Product[]>{
    return  this.http.get<Product[]>(`${this.baseUrl}Product/AllProducts`)
  }

  addProdut(objeto: SendProduct): Observable<object> {
      return this.http.post<object>(`${this.baseUrl}Product`, objeto)
    }

}
