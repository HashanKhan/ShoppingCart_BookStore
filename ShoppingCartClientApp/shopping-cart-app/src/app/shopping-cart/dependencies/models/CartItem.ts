export interface CartItem {
    id: number;
    name: string;
    type: string;
    author: string;
    price: number;
    stock: number;
    image: string;
    uuid?: any;
    remove?: boolean;
}