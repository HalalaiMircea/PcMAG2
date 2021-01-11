import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { Product } from '../../models/Product';
import { CartService } from '../../services/cart.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    public products: Product[] = [];

    constructor(
        private readonly productsService: ProductsService,
        private readonly cartService: CartService,
        private readonly router: Router
    ) {
        this.productsService.getProducts().subscribe(prodList => {
            // console.log(prodList);
            this.products = prodList;
        });
    }

    ngOnInit(): void {
    }

    public onAddToCartClick(product: Product): void {
        this.cartService.addCartItem(product.productId).subscribe(
            () => this.router.navigate(['/cart']),
            error => console.log(error)
        );
    }
}
