import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private snackBar: MatSnackBar
    ) { }

    //This is used to activate the needed route. 
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.getUserName();
        if (currentUser) {
            //logged in so return true
            return true;
        }

        //not logged in so redirect to login page with the return url
        this.openSnackBar("You have not being Logged IN.","Log IN");
        this.router.navigate(['/account/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }

    //Snackbar notification method.
    openSnackBar(message: string, action: string) {
        this.snackBar.open(message, action, {
        duration: 1500,
        });
    }
}