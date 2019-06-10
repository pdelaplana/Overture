import { Directive, Input, ElementRef, OnInit } from '@angular/core';

declare var $:any;

@Directive({
  selector: '[appIndicatorBar]'
})
export class IndicatorBarDirective implements OnInit {
  
  
  @Input() percentage : number;

  constructor(private el: ElementRef) { }

  ngOnInit(): void {
    let percentage = this.percentage.toFixed(0);

    $(this.el.nativeElement).find('span').css({
      width: percentage +'%'
    })


  }

}
