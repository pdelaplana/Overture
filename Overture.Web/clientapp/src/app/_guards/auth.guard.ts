import { AuthenticationService } from '@app/_services/authentication.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot){
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser){
      // authorised
      return true;
    }
   // not logged in so redirect to login page with the return url
   this.router.navigate(['/signin'], { queryParams: { returnUrl: state.url }});
   return false;
  }
}
