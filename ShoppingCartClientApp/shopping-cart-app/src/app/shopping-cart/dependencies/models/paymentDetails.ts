import { CartItem } from './CartItem';

export interface PaymentDetails {
    cart: CartItem[];
    total: number;
    paymentMethod: string;
    date: string;
    customerUserName: string;
};