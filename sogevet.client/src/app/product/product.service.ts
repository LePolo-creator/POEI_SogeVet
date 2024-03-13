import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from './model/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7265/api/products/';
  products: Product[] = []
  productsUpdated = new Subject<Product[]>()
  options = {
    headers: new HttpHeaders({ "content-type": "application/json" })
  }
  constructor(private http: HttpClient) { }

  
  getProducts() {
    this.http.get<Product[]>(this.apiUrl).subscribe(products => {
      this.products = products
      this.productsUpdated.next([...this.products])
    })
  }


  getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(this.apiUrl + id);
  }

  getStockLevel(id: number) : string {
    let product = this.products.find(p => p.id === id)
    let response = "";
    if (product!.quantity > 20) {
      response = "High"
    } else if (product!.quantity > 0) {
      response = "Low"
    } else {
      response = "None"
    }
    return response
  }

}

