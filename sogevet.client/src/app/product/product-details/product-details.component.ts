import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  productId!: number; 
  product: any;

  constructor(private route: ActivatedRoute, private productService: ProductService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.productId = +params['id']; 
      this.loadProductDetails();
    });
  }

  loadProductDetails(): void {
    this.productService.getProductById(this.productId).subscribe(
      response => {
        this.product = response;
      },
      error => {
        console.log(`Error loading product details for ID ${this.productId}:`, error);
      }
    );
  }
}
