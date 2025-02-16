import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { Login } from '../interfaces/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}
  isLoggedIn: boolean = false;
  private baseUrl: string = "https://localhost:7213/api/";//appsettings.apiUrl;

  login(objeto: User): Observable<Login> {
    return this.http.post<Login>(`${this.baseUrl}Auth/login`, objeto)
  }
}
