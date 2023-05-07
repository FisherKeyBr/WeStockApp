import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {

  }

  authenticate(loginDto: any) {
    const uri = '/api/Auth';
    return this.http.post<any>(uri, loginDto).toPromise();
  }
}
