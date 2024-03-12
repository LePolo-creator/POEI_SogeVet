import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { CartComponent } from './cart/cart.component';
import { AdminComponent } from './admin/admin.component';
import { ProductListComponent } from './product/product-list/product-list.component';
import { ProductDetailsComponent } from './product/product-details/product-details.component';

const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'cart', component: CartComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' } // Redirection vers la page d'accueil si l'URL ne correspond à aucune route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
