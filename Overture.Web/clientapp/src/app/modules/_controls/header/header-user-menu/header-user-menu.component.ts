import { NotificationService } from '@app/_services/notification.service';
import { Router } from '@angular/router';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Component, OnInit, HostListener, ElementRef, Input } from '@angular/core';

@Component({
  selector: 'app-header-user-menu',
  templateUrl: './header-user-menu.component.html',
  styleUrls: ['./header-user-menu.component.css']
})
export class HeaderUserMenuComponent implements OnInit {
  showDropdown:boolean;

  @Input() authenticated: Boolean;

  @HostListener('document:click', ['$event'])
  clickout(event) {
    if(!this.eRef.nativeElement.contains(event.target)) {
      this.showDropdown = false;
    }else {
      event.preventDefault();
    }
  }

  constructor(
    private eRef: ElementRef,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router
  ) { 
    this.showDropdown = false;
  }

  ngOnInit() {
  }

  toggleDropdown(){
    this.showDropdown = !this.showDropdown;
  }

  public signout(){
    this.authenticationService.logout();
    this.notificationService.success('You have successfully logged out');
    this.router.navigate(["/signin"]);
  }
}
