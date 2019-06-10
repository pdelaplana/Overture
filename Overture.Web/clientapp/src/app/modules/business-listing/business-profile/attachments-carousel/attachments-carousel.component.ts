import { StoredFile } from '@app/_models/stored-file';
import { Component, OnInit, Input } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-attachments-carousel',
  templateUrl: './attachments-carousel.component.html',
  styleUrls: ['./attachments-carousel.component.css']
})
export class AttachmentsCarouselComponent implements OnInit {
  private imageUrl = environment.baseUrl+'api/file' 

  slideConfig = {
    'slidesToShow': 4, 
    'slidesToScroll': 1, 
    'arrows': false, 
    'dots': true,
    'infinite': false
  };

  @Input() attachments: StoredFile[] = [];

  constructor() { }

  ngOnInit() {
  }

}
