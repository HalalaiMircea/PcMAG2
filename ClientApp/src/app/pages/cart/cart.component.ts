import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { CartItem } from '../../models/CartItem';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
    public cartItems: CartItem[] = [];

    constructor(private readonly service: CartService) {
        this.service.getCartItems().subscribe(value => {
            this.cartItems = value;
            console.log(value);
        });
    }

    ngOnInit(): void {
    }

    public onRemoveClick(item: CartItem): void {
        const index = this.cartItems.indexOf(item);
        this.cartItems.splice(index, 1);
        this.service.removeCartItem(item.productId)
            .subscribe({ error: err => console.log(err) });
    }
}
