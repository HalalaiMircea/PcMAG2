import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartItem } from '../models/CartItem';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CartService {
    private readonly cartApiURL = window.origin + '/api/cart';

    constructor(private readonly client: HttpClient) {
    }

    public getCartItems(): Observable<CartItem[]> {
        return this.client.get<CartItem[]>(this.cartApiURL);
    }

    public addCartItem(productId: number): Observable<CartItem[]> {
        return this.client.put<CartItem[]>(`${this.cartApiURL}/${productId}`, null);
    }

    public modifyQuantity(productId: number, quantity: number): Observable<CartItem[]> {
        return this.client.patch<CartItem[]>(`${this.cartApiURL}/${productId}`, quantity);
    }

    public removeCartItem(productId: number): Observable<CartItem[]> {
        return this.client.delete<CartItem[]>(`${this.cartApiURL}/${productId}`);
    }
}
