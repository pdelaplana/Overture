import { AuthenticationService } from '@app/_services/authentication.service';
import { Component, OnInit, ElementRef, HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  private loggedInAsCustomer:boolean;
  private loggedInAsBusinessOwner:boolean;
  isCloned:boolean;
  position: string;

  @HostListener('window:scroll', ['$event'])
  scrollEvent(event) {
    let width = window.innerWidth;
    if (width < 1099){
      this.isCloned = false;
    }
    if (width > 1099){
      this.position = 'fixed'; 
      let headerOffset = this.eRef.nativeElement.height;
      if (window.screenTop >= headerOffset){
        this.isCloned = true;
      } else{
        this.isCloned = false;
      }
    }
  }


  constructor (
    private eRef: ElementRef,
    private authenticationService: AuthenticationService
  ) { 
    
  }

  ngOnInit() {
    let user = this.authenticationService.currentUserValue; 
    if (user){
      this.loggedInAsBusinessOwner=(user.accountType == 'Business');
      this.loggedInAsCustomer=!this.loggedInAsCustomer;
    } else {
      this.loggedInAsBusinessOwner=false;
      this.loggedInAsCustomer=false;
    }
  }

  public get authenticated(): boolean {
    return this.loggedInAsCustomer || this.loggedInAsCustomer;
  }

  public get authenticatedAsBusiness(): boolean  {
    return this.loggedInAsBusinessOwner;
  }

  public get authenticatedAsCustomer(): boolean{
    return this.loggedInAsCustomer;
  }

  public login(){
    //this.authenticationService.login();
  }



  
}
