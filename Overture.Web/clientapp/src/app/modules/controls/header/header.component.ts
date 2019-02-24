import { Component, OnInit, ElementRef, HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  loggedInAsCustomer:boolean;
  loggedInAsBusinessOwner:boolean;
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


  constructor(private eRef: ElementRef) { 

  }

  ngOnInit() {
    this.loggedInAsBusinessOwner=true;
    this.loggedInAsCustomer=true;
  }

  

  
}
