import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './model/user';
import { Order } from './model/order';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService{
  private apiUrl = 'https://localhost:7265/api/users/';
  user?: User;
  orders: Order[] = [];
  ordersUpdated = new Subject<Order[]>()
  


  constructor(private http: HttpClient) { }
    

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
    return this.http.get<Order[]>(this.apiUrl + id + "/orders", options);
  }


}
