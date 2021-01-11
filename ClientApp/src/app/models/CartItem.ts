import { Product } from './Product';

export type CartItem = {
    userId: number,
    productId: number,
    quantity: number,
    product: Product,
};
