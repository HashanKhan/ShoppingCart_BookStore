import { CartItem } from './CartItem';

export interface StateTree {
    store: CartItem[];
    cart: CartItem[];
    tot: number,
    checkout: boolean;
};