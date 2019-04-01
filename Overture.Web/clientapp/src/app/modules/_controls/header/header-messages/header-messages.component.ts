import { Component, OnInit, ElementRef, HostListener } from '@angular/core';
import { Message } from '@app/_models/message';
import { MockMessages } from '@app/_mocks/mock-messages';

@Component({
  selector: 'app-header-messages',
  templateUrl: './header-messages.component.html',
  styleUrls: ['./header-messages.component.css']
})
export class HeaderMessagesComponent implements OnInit {
  showDropdown:boolean;
  messages:Message[];

  @HostListener('document:click', ['$event'])
  clickout(event) {
    if(!this.eRef.nativeElement.contains(event.target)) {
      this.showDropdown = false;
    }
  }

  constructor(private eRef: ElementRef) {
    this.showDropdown = false;
    this.messages = MockMessages;
   }

  ngOnInit() {
  }

  toggleDropdown(){
    this.showDropdown=!this.showDropdown;
  }

}
