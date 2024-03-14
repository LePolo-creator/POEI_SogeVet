import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../model/product';
import { Subscription } from 'rxjs';

@Component({<
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  productsToDisplay: Product[] = [];
  productSubscription?: Subscription;
  constructor(private productService: ProductService) { }



  ngOnInit(): void {
    this.productService.getProducts();

    this.productSubscription = this.productService.productsUpdated.subscribe(
      p => {
        this.products = p
        this.productsToDisplay = p;

      }
    );
  }
}
