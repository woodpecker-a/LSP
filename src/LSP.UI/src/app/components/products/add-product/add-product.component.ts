import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  addProductRequest: Product = {
    id: '',
    title: '',
    manufacturer: '',
    location: ''
  }
  constructor(private productsService: ProductsService) {}

  ngOnInit(): void {
  }
  
  addProduct()
  {
    console.log(this.addProductRequest)
    this.productsService.addProduct(this.addProductRequest)
    .subscribe({
      next: (product) => {
        console.log(product);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
