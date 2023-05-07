import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExceptionService {

  constructor() {

  }

  handleError(response: any) {
    console.log(response.error.Stack);
    alert(response.error.detail);
  }
}
