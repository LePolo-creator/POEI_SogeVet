import { Injectable, OnInit } from '@angular/core';
import { Cart } from '../model/cart';
import { CartItem } from '../model/cart-item';
import { ProductService } from '../../product/product.service';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService  {

  private cartItems: CartItem[] = []
 // cartItemsUpdated = new Subject<CartItem[]> 
  private cart?: Cart;
  cartUpdated = new Subject<Cart>


  constructor(private productService: ProductService) { }

  testCart() { // A SUPPRIMER
    this.addToCart(1, 3)
    this.addToCart(2, 1)
  }

  addToCart(productId: number, qty: number) {
   
    this.productService.getProductById(productId).subscribe(p => {
    const cartItemsFromStorage = localStorage.getItem("cart") ? JSON.parse(localStorage.getItem("cart")!)._cartItems : []
    console.log(localStorage.getItem("cart"))

    this.cartItems = cartItemsFromStorage
      console.log(this.cartItems)
      const newItem = new CartItem(productId, qty, p.unitPrice, p.unitPrice * qty, p)
      this.cartItems.push(newItem)

      /*
        this.cartItemsUpdated.next([...this.cartItems])
        travailler avec le cart ou cartitems??
      */
      this.cart = new Cart(this.cartItems, this.calculateTotal())

      
      localStorage.setItem("cart", JSON.stringify(this.cart))
      this.cartUpdated.next(this.cart)
    })
  }

  calculateTotal() {
    let total = 0;
    this.cartItems!.forEach(item => {
      total += item.totalPrice
    })
    return total
  }

  getCart(): Cart {
    return this.cart!
  }

  getCartItems(): CartItem[] {
    return this.cartItems
  }


/*  parseJsonToCart(jsonStr: string) {
    let cart = new Cart();
    let jsonObj = JSON.parse(jsonStr);

    for (let prop in jsonObj) {
        this[prop] = jsonObj[prop];
      }
    
  }*/

}
