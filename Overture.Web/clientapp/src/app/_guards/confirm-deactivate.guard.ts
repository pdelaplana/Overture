import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot,CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';

export interface CanComponentDeactivate {
  canDeactivate: () => Observable<boolean> | Promise<boolean> | boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ConfirmDeactivateGuard implements CanDeactivate<CanComponentDeactivate> {
  canDeactivate(target:CanComponentDeactivate){

    if (target.canDeactivate){
      if (!target.canDeactivate()){
        if (confirm('You have unsaved changes! If you leave, your changes will be lost.')) {
            return true;
        } else {
            return false;
        }
      }
    } 
    return true;
  }
}
