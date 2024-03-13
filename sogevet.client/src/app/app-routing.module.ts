import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';


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
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
