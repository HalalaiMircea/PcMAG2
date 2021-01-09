import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './models/Product';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ProductsService {
    private readonly productsUrl = window.origin + '/api/products';

    constructor(
        private readonly client: HttpClient
    ) {
    }

    public getProducts(): Observable<Product[]> {
        return this.client.get<Product[]>(this.productsUrl);
    }
}
