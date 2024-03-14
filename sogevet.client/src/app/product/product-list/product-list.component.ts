import { Component, OnInit,Input   } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../model/product';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  selectedColors: { [key: string]: boolean } = {};
  selectedSizes: { [key: string]: boolean } = {};


  products: Product[] = [];
  productsToDisplay: Product[] = [];
  productSubscription?: Subscription;
  filteredProducts?: Product[];
  categoryName?: string;
  filter: string = "";
  colors: string[] = []
  sizes: number[] = []


  constructor(private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private router:Router) { }

  filterProducts(keyword?: string, min?: number, max?: number) {
    this.filteredProducts = this.productsToDisplay
    //console.log('Selected Colors:', this.selectedColors);
    //console.log('Selected Sizes:', this.selectedSizes);
    if (keyword) {
      this.filteredProducts = this.filteredProducts.filter(p => 
        p.name.toLowerCase().includes(keyword.toLowerCase()) || p.description.toLowerCase().includes(keyword.toLowerCase())
      )}
    if (max) {
      this.filteredProducts = this.filteredProducts.filter(p => p.unitPrice <= +max);
    }
    if (min) {
      this.filteredProducts = this.filteredProducts.filter(p => p.unitPrice >= +min);
    }

    // filtre couleur
    const selectedColorKeys = Object.keys(this.selectedColors).filter(key => this.selectedColors[key]);
    if (selectedColorKeys.length > 0) {
      this.filteredProducts = this.filteredProducts.filter(p => selectedColorKeys.includes(p.color));
    }

    // Filtre taille
    const selectedSizes = Object.keys(this.selectedSizes).filter(key => this.selectedSizes[key]).map(Number);
    if (selectedSizes.length > 0) {
      this.filteredProducts = this.filteredProducts.filter(p => selectedSizes.includes(p.size));
    }
  }


  ngOnInit(): void {

    this.activatedRoute.params.subscribe(
      parametres => {
        if (parametres['categoryName'] != "") {
          this.categoryName = parametres['categoryName'];
          switch (this.categoryName) {
            case "men":
              this.categoryName = "Men"
              this.filter = "homme"
              break;
            case "women":
              this.categoryName = "Women"
              this.filter = "femme"
              break;
            case "child":
              this.categoryName = "Child"
              this.filter = "enfant"
              break;
            default:
              this.categoryName = "All Products";
              this.filter = "";
          }
        }
        if (this.filter == "") {
          this.productService.getProducts();

        } else {
          this.productService.getProductsFilter(this.filter);
        }
        /*console.log(this.categoryName);
        console.log(this.filter);*/
      }
    );

    
    

    this.productSubscription = this.productService.productsUpdated.subscribe(
      p => {
        
        this.products = p
        this.colors = this.productService.colors
        this.sizes = this.productService.sizes

        this.productsToDisplay = p;
        this.filteredProducts = p;
      }
    );
  }
}
