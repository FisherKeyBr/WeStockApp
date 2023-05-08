import { Component } from '@angular/core';
import { ExceptionService } from '../exception.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  constructor(private userService: UserService, private exceptionService: ExceptionService) {

  }

  formData: any = {
    username: '',
    password: '',
    displayName: ''
  };

  onRegisterClick() {
    this.userService.register(this.formData).then(() => {
      alert('The user was created!');
    }).catch((err:any) => this.exceptionService.handleError(err));
  }
}
