import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login/service/login.service';
import { CartService } from '../cart/service/cart.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{
  constructor(private loginService: LoginService, private cartService: CartService) { }

  showList: boolean = false;
  nbItems?: number; 

  logout() {
    if (confirm("Etes-vous sûrs de vouloir vous deconnecter?")) {
      this.loginService.logout();
    }
  }
  toggleList() {
    this.showList = !this.showList
  }


  isLogged(): boolean {
    return this.loginService.isAuthenticated()
  }

  ngOnInit() {
    this.cartService.cartUpdated.subscribe(cart => this.nbItems = cart.cartItems.length)
  }
}
