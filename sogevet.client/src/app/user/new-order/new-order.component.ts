import { Component, OnInit } from '@angular/core';
import { Cart } from '../../cart/model/cart';
import { OrderService } from '../service/order.service';
import { CartService } from '../../cart/service/cart.service';
import { User } from '../model/user';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit {
  cart?: Cart
  user? : User

  constructor(private orderService: OrderService, private cartService: CartService,
    private userService: UserService, private router : Router
  ) { }
  
  newOrder() {
    this.orderService.newOrder(this.cart!)
    this.router.navigate(["/account"])
  }

  ngOnInit() {
    this.cart = this.cartService.getCart()
    this.userService.getUserbyId(JSON.parse(localStorage.getItem("authSogevet")!).idUser).subscribe(u => {
      this!.user = u;
      console.log(this.user);
    });
    //this.userService.getUserbyId(3).subscribe(u => this.user = u)
    console.log(this.cart)
  }
  
}
