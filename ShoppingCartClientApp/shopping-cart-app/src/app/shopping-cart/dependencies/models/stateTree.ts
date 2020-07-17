import { CartItem } from './CartItem';
import { Books } from './books';

export interface StateTree {
    store: Books[];
    cart: CartItem[];
    tot: number;
    checkout: boolean;
};