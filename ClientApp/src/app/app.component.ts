import { Component, OnInit } from '@angular/core';
import { ProductsService } from './products.service';
import { Product } from './models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PcMAG';
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
