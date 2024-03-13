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

/*  calculateTotal() {
    let total = 0;
    this.cartItems!.forEach(item => {
      total += item.totalPrice
    })
    return total
  }*/

  constructor(private cartService: CartService) { }
  ngOnInit() {
    // a supprimer
    this.cartService.testCart()
    this.cartItems = this.cartService.getCartItems()


/*    this.cartService.cartItemsUpdated.subscribe(items => {
      this.cartItems = items
      console.log(this.cartItems)
      const total = this.calculateTotal()
    })*/

    this.cartService.cartUpdated.subscribe(cart => { this.cart = cart, this.cartItems = this.cart.cartItems })
  }

}
