import { RefreshToken } from './refreshToken';

export interface AccessToken {
    token: string,
    expiration: number,
    refreshToken: RefreshToken
}