import { Directive, ElementRef } from '@angular/core';

declare var tippy:any;

@Directive({
  selector: '[appTippyTooltips]'
})
export class TippyTooltipsDirective {

  constructor(private el:ElementRef) { 
    tippy(el.nativeElement,  {
      delay: 100,
      arrow: true,
      arrowType: 'sharp',
      size: 'regular',
      duration: 200,
  
      // 'shift-toward', 'fade', 'scale', 'perspective'
      animation: 'shift-away',
  
      animateFill: true,
      theme: 'dark',
  
      // How far the tooltip is from its reference element in pixels 
      distance: 10,
  
    })
  }

}
