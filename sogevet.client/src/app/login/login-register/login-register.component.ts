import { Component } from '@angular/core';
import { LoginService } from '../service/login.service';

@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.css']
})
export class LoginRegisterComponent {
  constructor(private loginService:LoginService) {

  }

  register(firstname: string, lastname: string, email: string, password: string, address: string) {
    this.loginService.register(firstname, lastname, email, password, address);
  }

}
