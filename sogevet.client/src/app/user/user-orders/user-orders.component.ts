import { Component, OnInit } from '@angular/core';
import { Order } from '../model/order';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IOrderToDisplay } from '../model/iorder-to-display';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit{
  userOrders: Order[] = [];
  userOrderToDisplay: IOrderToDisplay[] = [];
  filteredUserOrders?: Order[];
  userOrdersSubscription?: Subscription;

  constructor(private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }



  filterOrders(status?: string, keyword?: string, min?: number, max?: number) {
    this.filteredUserOrders = this.userOrders;
    if (status) {
      this.filteredUserOrders = this.filteredUserOrders.filter(o => o.status == status)
    }
    /*if (max) {
      this.filteredUserOrders = this.filteredUserOrders.filter(o => o.totalPrice <= +max);
    }
    if (min) {
      this.filteredUserOrders = this.filteredUserOrders.filter(o => o.totalPrice >= +min);
    }*/
  }
  



  ngOnInit(): void {
    this.userService.getOrdersOfUserId(JSON.parse(localStorage.getItem("authSogevet")!).idUser);
    

    this.userOrdersSubscription = this.userService.ordersUpdated.subscribe(
      p => {

        this.userOrders = p;
        this.userOrders.forEach(order => {
          this.userOrderToDisplay?.push(this.userService.convertToDisplay(order));
        })
      }
    );
  }

}
