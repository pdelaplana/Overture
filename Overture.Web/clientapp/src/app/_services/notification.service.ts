import { Router, NavigationStart } from '@angular/router';
import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

declare var notify: any;


@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private subject = new Subject<any>();
  private keepAfterNavigationChange = false;

  constructor(private router:Router) { 
    // clear alert message on route change
    router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        if (this.keepAfterNavigationChange) {
            // only keep for a single location change
            this.keepAfterNavigationChange = false;
        } else {
            // clear alert
            this.subject.next();
        }
      }
    });
  }

  success(message: string, keepAfterNavigationChange = false) {
    this.keepAfterNavigationChange = keepAfterNavigationChange;
    this.subject.next({ type: 'success', text: message });
    notify(message, 3000);
  }

  error(message: string, keepAfterNavigationChange = false) {
    this.keepAfterNavigationChange = keepAfterNavigationChange;
    this.subject.next({ type: 'error', text: message });
  }

  info(message: string, keepAfterNavigationChange = false) {
    this.keepAfterNavigationChange = keepAfterNavigationChange;
    this.subject.next({ type: 'info', text: message });
  }

  pin(message:string, keepAfterNavigationChange = false){
    this.keepAfterNavigationChange = keepAfterNavigationChange;
    this.subject.next({ type: 'info', text: message });
    notify(message, null);
  }

  getMessage(): Observable<any> {
      return this.subject.asObservable();
  }
}
