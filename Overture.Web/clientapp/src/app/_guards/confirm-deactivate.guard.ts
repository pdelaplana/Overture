import { ManagementBusinessProfileComponent } from './../modules/management/management-business-profile/management-business-profile.component';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot,CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfirmDeactivateGuard implements CanDeactivate<ManagementBusinessProfileComponent> {
  canDeactivate(target:ManagementBusinessProfileComponent):boolean{
    if(target.hasChanges){
      if (confirm('You have unsaved changes! If you leave, your changes will be lost.')) {
          return true;
      } else {
          return false;
      }
  }
  return true;
  }
}
