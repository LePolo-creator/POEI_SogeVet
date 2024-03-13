import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../product.service';
import { Product } from '../model/product';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  productId!: number;
  product?: Product;
  stockLevel?: string;

  constructor(private route: ActivatedRoute, private productService: ProductService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.productId = +params['id'];
      this.productService.getProducts();
      this.loadProductDetails();
    });
  }


  loadProductDetails(): void {
    this.productService.getProductById(this.productId).subscribe(
      product => {
        this.product = product;
        this.productService.getProductById(this.productId)

        this.stockLevel = this.productService.getStockLevel(this.productId)
      },
      error => {
        console.log(`Error loading product details for ID ${this.productId}:`, error);
      }
    );
  }

  addToCart(id: number, qty: number): void {
    console.log(qty)
    console.log(id)

  }
}

