import { Directive, ElementRef, OnInit, Input } from '@angular/core';

declare var $:any;

@Directive({
  selector: '[appMagnificPopupDialog]'
})
export class MagnificPopupDialogDirective implements OnInit {
  
  @Input() id : string;

  constructor(private el: ElementRef) { 

  }

  ngOnInit(): void {
    $(this.el.nativeElement).magnificPopup({
      type: 'inline',

      items:{
        src: '#'+this.id,
        //src: '#small-dialog',
        //src:'<div>hello world</div>',
        //src: '<div class="white-popup">Dynamically created popup</div>',
        type:'inline'
      },
 
      fixedContentPos: true,
      fixedBgPos: true,
 
      overflowY: 'auto',
 
      closeBtnInside: true,
      preloader: false,
 
      midClick: true,
      removalDelay: 300,
      mainClass: 'my-mfp-zoom-in'
   });
  }


}
