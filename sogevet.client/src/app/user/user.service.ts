import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './model/user';
import { Order } from './model/order';
import { Observable, Subject } from 'rxjs';
import { IOrderToDisplay } from './model/iorder-to-display';

@Injectable({
  providedIn: 'root'
})
export class UserService{
  private apiUrl = 'https://localhost:7265/api/users/';
  user?: User;
  orders: Order[] = [];
  ordersUpdated = new Subject<Order[]>()
  


  constructor(private http: HttpClient) { }
    



  convertToDisplay(order: Order): IOrderToDisplay {

    return {
      id: order.id,
      address: order.address,
      status: order.status,
      orderItems: order.orderItems,
      totalPrice: this.getTotalPrice(order.id),
      totalQuantity: this.getTotalQuantity(order.id)
    } as IOrderToDisplay
  }

  getTotalPrice(id: number) {
    const order = this.orders.find(o => o.id == id)
    let totalPrice = 0
    order?.orderItems.forEach(item => {
      totalPrice += item.quantity * item.unitPrice
    })
    return totalPrice
  }


  getTotalQuantity(id: number) {
    const order = this.orders.find(o => o.id == id)
    let totalQuantity = 0
    order?.orderItems.forEach(item => {
      totalQuantity += item.quantity
    })
    return totalQuantity
  }



  getUserbyId(id: number): Observable<User> {
    /*console.log(this.options)*/
    const options = {
      headers: new HttpHeaders(
        {
          "content-type": "application/json",
          "authorization": "Bearer " + JSON.parse(localStorage.getItem("authSogevet")!).token || ""
        }
      )
    }
    return this.http.get<User>(this.apiUrl + id, options);
  }

  getOrdersOfUserId(id: number) {
    const options = {
      headers: new HttpHeaders(
        {
          "content-type": "application/json",
          "authorization": "Bearer " + JSON.parse(localStorage.getItem("authSogevet")!).token || ""
        }
      )
    }
    return this.http.get<Order[]>(this.apiUrl + id + "/orders", options).subscribe(
      orders => {
        this.orders = orders;
        this.ordersUpdated.next([...this.orders]);
        console.log(orders);
      }
    );
  }


}
