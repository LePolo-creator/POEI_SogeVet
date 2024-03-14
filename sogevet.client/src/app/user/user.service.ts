import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './model/user';
import { Order } from './model/order';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7265/api/users/';
  user?: User;
  orders: Order[] = [];
  ordersUpdated = new Subject<Order[]>()
  options = {
    headers: new HttpHeaders({ "content-type": "application/json" })
  }


  constructor(private http: HttpClient) { }

  getUserbyId(id: number): Observable<User> {
    return this.http.get<User>(this.apiUrl + id);
  }

  getOrdersOfUserId(id: number) {
    return this.http.get<Order[]>(this.apiUrl + id + "/orders");
  }

}
