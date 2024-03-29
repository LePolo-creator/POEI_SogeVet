import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsRoutingModule } from './product-routing.module';

import { ProductCardComponent } from './product-card/product-card.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailsComponent,
    ProductCardComponent,
],
  imports: [
    CommonModule, ProductsRoutingModule, FormsModule
  ]
})
export class ProductModule { }
