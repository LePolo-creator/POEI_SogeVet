import { Component, OnInit } from '@angular/core';
import { CartItem } from './model/cart-item';
import { Cart } from './model/cart';
import { CartService } from './service/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = []
  cart?: Cart 
  constructor(private cartService: CartService) { }


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
