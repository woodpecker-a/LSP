import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  apiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl + '/v3/Product');
  }

  addProduct(addProductRequest: Product) : Observable<Product> {
    addProductRequest.id =  '00000000-0000-0000-0000-000000000000';
    return this.http.post<Product>(this.apiUrl + '/v3/Product', addProductRequest)
  }
}
