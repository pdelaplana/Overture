import { Directive, ElementRef } from '@angular/core';

declare var $:any;

@Directive({
  selector: '[appAttachmentsCarousel]'
})
export class AttachmentsCarouselDirective {

  constructor(private el: ElementRef) { 
    $(el.nativeElement).slick({
      infinite: true,
      slidesToShow: 5,
      slidesToScroll: 1,
      dots: true,
      arrows: true,
      /*
      responsive: [
        {
          breakpoint: 1365,
          settings: {
          slidesToShow: 5,
          dots: true,
          arrows: false
          }
        },
        {
          breakpoint: 992,
          settings: {
          slidesToShow: 3,
          dots: true,
          arrows: false
          }
        },
        {
          breakpoint: 768,
          settings: {
          slidesToShow: 1,
          dots: true,
          arrows: false
          }
        }
      ]
      */
    });
  }

}
