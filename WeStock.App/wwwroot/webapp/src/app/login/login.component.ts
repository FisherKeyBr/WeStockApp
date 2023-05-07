import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { ExceptionService } from '../exception.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginDto: any = {
    username: '',
    password: ''
  };

  constructor(private authService: AuthService, private exceptionService: ExceptionService) {

  }

  onForgetPasswordClick() {
    alert("In development!");
  }

  onLoginClick() {
    this.authService.authenticate(this.loginDto).then((response) => {
      console.log(response);
    }).catch((err) => this.exceptionService.handleError(err));
  }
}
