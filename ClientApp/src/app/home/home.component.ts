import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Product } from '../models/Product';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public products: Product[] = [];

  constructor(private service: ProductsService) {
  }

  ngOnInit(): void {
    this.service.getProducts().subscribe(prodList => {
      // console.log(prodList);
      this.products = prodList;
    });
  }

}
