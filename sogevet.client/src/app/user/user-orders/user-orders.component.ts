import { Component, OnInit } from '@angular/core';
import { Order } from '../model/order';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit{
  userOrders: Order[] = [];
  userOrderToDisplay: Order[] = [];
  filteredUserOrders?: Order[];
  userOrdersSubscription?: Subscription;

  constructor(private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }
  














  ngOnInit(): void {

    this.activatedRoute.params.subscribe(
      parametres => {
        const userID = 3;


        this.userService.getOrdersOfUserId(userID);
        /*console.log(this.categoryName);
        console.log(this.filter);*/
      }
    );




    this.userOrdersSubscription = this.userService.ordersUpdated.subscribe(
      p => {

        this.userOrders = p;
        this.userOrderToDisplay = p;
        this.filteredUserOrders = p;
      }
    );
  }

}
