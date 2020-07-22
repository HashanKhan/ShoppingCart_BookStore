import { CartItem } from './CartItem';
import { Books } from './books';
import { Total } from './total';

export interface StateTree {
    store: Books[];
    cart: CartItem[];
    tot: Total;
    checkout: boolean;
};