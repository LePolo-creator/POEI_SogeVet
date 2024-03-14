import { Component } from '@angular/core';
import { LoginService } from '../login/service/login.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  constructor(private loginService : LoginService) { }
  logout() {
    if (confirm("Etes-vous sûrs de vouloir vous deconnecter?")) {
      this.loginService.logout();
    }
  }
}
