import { Injectable } from '@angular/core';
import { Cart } from '../../cart/model/cart';
import { OrderItems } from '../model/order-items';
import { CartItem } from '../../cart/model/cart-item';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Order } from '../model/order';
import { UserService } from '../user.service';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  // IL FAUT UserId
  ordersUpdated = Subject<Order>
  cart? : Cart

  baseUrl = "https://localhost:7265/api/";

  options = {
    headers: new HttpHeaders(
      {
        "content-type": "application/json",
        "authorization": "Bearer " + JSON.parse(localStorage.getItem("authSogevet")!).token || ""
      }
    )
  }
  constructor(private http: HttpClient, private userService: UserService) { }


  newOrder(cart: Cart) {
    const cartItems = cart.cartItems

    this.userService.getUserbyId(2).subscribe(user => {
      this.http.post<Order>(
        this.baseUrl+"orders",
        JSON.stringify({
          Address: user.address,
          Status: "En attente de traitement",
          OrderItems: [],
          UserId: user.id
        }),
        this.options).subscribe(order => {
          cartItems.forEach(item => {
            this.http.post<OrderItems>(
              this.baseUrl+"orderItems",
              JSON.stringify({
                quantity: item.quantity,
                unitPrice: item.unitPrice,
                orderId: order.id,
                productId: item.productId,
                productName: item.product.name,
                totalPrice: item.totalPrice
              }),
              this.options
            ).subscribe(i => console.log(i))
          })
        })
    })
  }

/*  addOrderItemInDb(item: car) {
    console.log(item)
    this.http.post<OrderItems>(
      this.baseUrl,
      item,
      this.options
    )
  }*/
}
