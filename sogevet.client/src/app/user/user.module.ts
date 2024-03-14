import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './user-routing.module';
import { UserAccountComponent } from './user-account/user-account.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { NewOrderComponent } from './new-order/new-order.component';



@NgModule({
  declarations: [
    UserAccountComponent,
    UserOrdersComponent,
    NewOrderComponent
  ],

  imports: [
    CommonModule,
    UsersRoutingModule
    
  ]
})
export class UserModule { }
