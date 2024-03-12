import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7265/api/products/'; 
  constructor(private http: HttpClient) { }

  
  getProducts(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}`).pipe(
      catchError(error => {
        console.log('Error fetching products:', error);
        throw error;
      })
    );
  }

  getProductById(productId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}${productId}`).pipe(
      catchError(error => {
        console.log(`Error fetching product with ID ${productId}:`, error);
        throw error;
      })
    );
  }
}
