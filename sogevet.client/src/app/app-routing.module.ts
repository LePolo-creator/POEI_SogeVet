import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';


const routes: Routes = [

  {
    path: "products",
    loadChildren: () => import("./product/product.module").then(m => m.ProductModule)
  }, {
    path: "cart", component: CartComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
