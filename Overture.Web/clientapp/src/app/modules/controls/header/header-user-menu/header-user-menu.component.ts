import { Component, OnInit, HostListener, ElementRef } from '@angular/core';

@Component({
  selector: 'app-header-user-menu',
  templateUrl: './header-user-menu.component.html',
  styleUrls: ['./header-user-menu.component.css']
})
export class HeaderUserMenuComponent implements OnInit {
  showDropdown:boolean;

  @HostListener('document:click', ['$event'])
  clickout(event) {
    event.preventDefault();
    if(!this.eRef.nativeElement.contains(event.target)) {
      this.showDropdown = false;
    }
  }

  constructor(private eRef: ElementRef) { 
    this.showDropdown = false;
  }

  ngOnInit() {
  }

  toggleDropdown(){
    this.showDropdown = !this.showDropdown;
  
  }

}
