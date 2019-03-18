
import { Component, OnInit } from '@angular/core';
import { NotificationService } from '@app/_services/notification.service';
import { AuthenticationService } from '@app/_services/authentication.service';
import { User } from '@app/_models/user';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-management-sidebar',
  templateUrl: './management-sidebar.component.html',
  styleUrls: ['./management-sidebar.component.css']
})
export class ManagementSidebarComponent implements OnInit {
  private currentUser : User;
  private currentUserSubscription: Subscription;
  
  constructor(
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
  }

  notifyTest(){
    this.notificationService.success("This is a test.")
  }

}
