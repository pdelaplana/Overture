import { Directive, ElementRef, OnInit } from '@angular/core';

declare var $:any;

@Directive({
  selector: '[appBootstrapSelect]'
})
export class BootstrapSelectDirective implements OnInit{
  
  constructor(private el: ElementRef) { 
    
  }

  ngOnInit(): void {
    $(this.el.nativeElement).selectpicker();
  }


}
