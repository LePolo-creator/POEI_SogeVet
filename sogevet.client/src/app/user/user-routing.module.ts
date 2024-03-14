import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserAccountComponent } from './user-account/user-account.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { authGuard } from '../shared/auth.guard';
import { NewOrderComponent } from './new-order/new-order.component';



const routes: Routes = [
  {
    path: "", component: UserAccountComponent, canActivate: [authGuard]
  },
  {
    path: "orders", component: UserOrdersComponent, canActivate: [authGuard]
  },
  {
    path: "neworder", component: NewOrderComponent, canActivate: [authGuard]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
