import { Component } from '@angular/core';
import { Router } from '@angular/router';
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

  //making this really dumb and simple
  constructor(private authService: AuthService, private exceptionService: ExceptionService,
    private router: Router) {

    var isLoggedIn = localStorage.getItem('token') != null;

    if (isLoggedIn) {
      this.router.navigate(['/']);
    }

  }

  onForgetPasswordClick() {
    alert("In development!");
  }

  onLoginClick() {
    this.authService.authenticate(this.loginDto).then((response) => {
      console.log(response);
      localStorage.setItem('token', response.token);
      this.router.navigate(['/']);

    }).catch((err) => this.exceptionService.handleError(err));
  }
}
