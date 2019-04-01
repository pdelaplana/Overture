import { Directive, ElementRef, Input, OnInit } from '@angular/core';


declare var $:any;


@Directive({
  selector: '[appMagnificPopup]'
})
export class MagnificPopupDirective implements OnInit{
  

  @Input() src: string;

  constructor(private el: ElementRef) { 
    

  }

  ngOnInit(): void {
    $(this.el.nativeElement).magnificPopup({
      type: 'image',
      items:{
        //src: 'https://localhost:44371/api/file/5ca1288f391777131c60fd0f'
        src: this.src
      },
      closeOnContentClick: true,
      mainClass: 'mfp-fade',
      image: {
         verticalFit: true
      }
   });
  }

}
