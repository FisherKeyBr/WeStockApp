import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) {

  }

  register(formData: any) {
    const uri = "/api/User/newUser";
    return this.http.post<any>(uri, formData).toPromise();
  }
}
