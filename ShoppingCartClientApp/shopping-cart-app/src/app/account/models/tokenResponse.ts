import { Customers } from './customers';
import { AccessToken } from './accessToken';

export interface TokenResponse {
    success: boolean, 
    message: string, 
    token: AccessToken,
    customer: Customers
}