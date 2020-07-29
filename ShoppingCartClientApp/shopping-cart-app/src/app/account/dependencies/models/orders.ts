import { Customers } from './customers';

export interface Orders {
    id: number;
    dateCreated: string;
    totalAmount: number;
    customer: Customers;
}