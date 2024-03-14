import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IndexComponent } from './index/index.component';
import { CartComponent } from './cart/cart.component';
import { authGuard } from './shared/auth.guard';



const routes: Routes = [

  {
    path: "products",
    loadChildren: () => import("./product/product.module").then(m => m.ProductModule)
  },
  /*{
    path: "",
    loadChildren: () => import("./product/product.module").then(m => m.ProductModule)
  },*/
  {
    path: "", component : IndexComponent
  },
  {
    path: "products/filter/:categoryName", component: IndexComponent

  },
  {
    path: "cart", component: CartComponent

  },
  {
    path: "login",
    loadChildren: () => import("./login/login.module").then(m => m.LoginModule)
  },
  {
    path: "account",
    loadChildren: () => import("./user/user.module").then(m => m.UserModule), canActivate: [authGuard]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
