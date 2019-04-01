import { Notification } from '@models/notification';
import { MockNotifications } from '@mocks/mock-notifications';
import { Component, OnInit, ElementRef, HostListener, } from '@angular/core';


@Component({
  selector: 'app-header-notifications',
  templateUrl: './header-notifications.component.html',
  styleUrls: ['./header-notifications.component.css']
})
export class HeaderNotificationsComponent implements OnInit {
  notifications: Notification[];
  showDropdown:boolean

  @HostListener('document:click', ['$event'])
  clickout(event) {
    if(!this.eRef.nativeElement.contains(event.target)) {
      this.showDropdown = false;
    }
  }

  constructor(private eRef: ElementRef) { 
    this.showDropdown=false;
    this.notifications = MockNotifications;
  }

  ngOnInit() {
  }

  toggleDropdown(){
    this.showDropdown=!this.showDropdown;
  }

  

}
