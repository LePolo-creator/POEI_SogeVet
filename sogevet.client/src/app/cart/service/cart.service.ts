import { Injectable, OnInit } from '@angular/core';
import { Cart } from '../model/cart';
import { CartItem } from '../model/cart-item';
import { ProductService } from '../../product/product.service';
import { Subject } from 'rxjs';
import { ICartItem } from '../model/i-cart-item';
import { Product } from '../../product/model/product';
import { OrderService } from '../../user/service/order.service';

@Injectable({
  providedIn: 'root'
})
export class CartService implements OnInit  {

  private cartItems: CartItem[] = []
  cartItemsUpdated = new Subject<CartItem[]> 
  private cart?: Cart;
  cartUpdated = new Subject<Cart>


  constructor(private productService: ProductService, private orderService : OrderService){ }

  submitOrder() {
    this.orderService.newOrder(this.getCart())
  }

 
  changeQuantity(productId: number, newQty: number) {
    if (newQty === 0) {
      if (confirm("Etes-vous sûr de supprimer du panier?")) {
        this.cartItems = this.cartItems.filter(item => item.productId !== productId)
      }
    }
    else {
      this.cartItems.map(item => {
        if (item.productId === productId) {
          item.quantity = newQty
          item.totalPrice = newQty * item.unitPrice
        }
      })
    }

    this.cart = new Cart(this.cartItems, this.calculateTotal())
    console.log(this.cartItems)
    this.cartUpdated.next(this.cart)

    localStorage.setItem("cart", JSON.stringify(this.cart))
  }

  getItemsFromStorage() {
    let icartItemsFromStorage = localStorage.getItem("cart") ? JSON.parse(localStorage.getItem("cart")!)._cartItems as ICartItem[] : []
    let cartItemsFromStorage : CartItem[] = []
    icartItemsFromStorage.forEach(item => {
      const cartItem = new CartItem(item._productId, item._quantity, item._unitPrice, item._totalPrice, item._product as Product)
      cartItemsFromStorage.push(cartItem)
    })

    this.cartItems = cartItemsFromStorage
    this.cart = new Cart(this.cartItems, this.calculateTotal())

    return cartItemsFromStorage
  }


  alreadyInCart(productId : number): Boolean {
    this.cartItems = this.getCartItems()
    const inCart = this.cartItems.filter(item => item.productId === productId).length
    return inCart? true : false
  }

  addToCart(productId: number, qty: number) {
    // vérifie si on l'a déjà dans le panier

    

    this.productService.getProductById(productId).subscribe(p => {

      // Récupère les items du localStorage
      this.cartItems = this.getItemsFromStorage()
      console.log(this.cartItems)


      // Rajout du produit au panier
      const newItem = new CartItem(productId, qty, p.unitPrice, p.unitPrice * qty, p)
      this.cartItems.push(newItem)

      // mise à jour du panier
      this.cart = new Cart(this.cartItems, this.calculateTotal())
      this.cartUpdated.next(this.cart)

      // envoi du nouveau panier au storage
      localStorage.setItem("cart", JSON.stringify(this.cart))
    })
  }

/*      this.cartItemsUpdated.next([...this.cartItems])
      
      this.cartItemsUpdated.subscribe(cartItems => cartItems.forEach(item => console.log(typeof(item))))*/

  calculateTotal(): number {
    //const items = this.getItemsFromStorage()
    const items = this.cartItems

    let total = 0;
    items!.forEach(item => {
      //console.log(item, item.totalPrice, typeof(item.totalPrice))
      total += item.totalPrice
    })
    return total
  }

  getCart(): Cart {
    this.getItemsFromStorage()
    return this.cart!
  }

  getCartItems(): CartItem[] {
    this.getItemsFromStorage()
    return this.cartItems
  }

  ngOnInit() {
    this.cart = new Cart(this.getItemsFromStorage(), this.calculateTotal())
    console.log(this.cart)
  }


}
