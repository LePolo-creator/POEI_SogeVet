import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsRoutingModule } from './product-routing.module';
import { ProductCardComponent } from './product-card/product-card.component';




@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailsComponent,
    ProductCardComponent,
],
  imports: [
    CommonModule, ProductsRoutingModule
  ]
})
export class ProductModule { }
