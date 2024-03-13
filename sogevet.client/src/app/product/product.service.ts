import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from './model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7265/api/products/';
  products?: Product[]
  productsUpdated = new Subject<Product[]>()
  constructor(private http: HttpClient) { }

  
  getProducts() {
    this.http.get<Product[]>(this.apiUrl).subscribe(products => {
      this.products = products
      this.productsUpdated.next([...this.products])
    })
  }

  getProductsFilter(filter : string) {
    this.http.get<Product[]>(this.apiUrl+"filter/"+filter).subscribe(products => {
      this.products = products
      this.productsUpdated.next([...this.products])
    })
  }


  getProductById(productId: number): Observable<any> {


    return this.http.get<any>(this.apiUrl+productId).pipe(

      catchError(error => {
        console.log(`Error fetching product with ID ${productId}:`, error);
        throw error;
      })
    );
  }
}
