import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './user-routing.module';
import { UserAccountComponent } from './user-account/user-account.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';



@NgModule({
  declarations: [
    UserAccountComponent,
    UserOrdersComponent
  ],

  imports: [
    CommonModule,
    UsersRoutingModule
    
  ]
})
export class UserModule { }
