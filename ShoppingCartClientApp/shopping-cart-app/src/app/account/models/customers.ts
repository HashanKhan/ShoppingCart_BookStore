import { DatePipe } from '@angular/common';

export interface Customers {
    id: number;
    name: string;
    phone: string;
    email: string;
    address: string;
    userName: string;
    password: string;
    loginStatus: boolean;
    registerDate: string;
}