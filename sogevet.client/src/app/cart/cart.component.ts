import { Component, OnInit } from '@angular/core';
import { CartItem } from './model/cart-item';
import { Cart } from './model/cart';
import { CartService } from './service/cart.service';
import { OrderService } from '../user/service/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = []
  cart?: Cart
  constructor(private cartService: CartService, private orderService: OrderService, private router : Router) { }

/*  submitOrder() {
    this.cartService.submitOrder();
    // router
  }*/

  goToOrder() {
    this.router.navigate(["/account/neworder"])
  }

  changeQtyInCart(productId: number, newQty: number) {
    this.cartService.changeQuantity(productId,newQty)
  }

  ngOnInit() {
    this.cart = this.cartService.getCart()
    this.cartItems = this.cartService.getCartItems()
   
    this.cartService.cartUpdated.subscribe(cart => {
      this.cart = cart
      this.cartItems = this.cart.cartItems
    })
   // this.cartItems = this.cartService.getCartItems()
   //   this.cartService.cartItemsUpdated.subscribe(items => { this.cartItems = items })
  }

}
