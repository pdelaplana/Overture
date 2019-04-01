import { Business } from '@app/_models/business';
import { Component, OnInit, Input, ChangeDetectionStrategy, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { PaginationInstance } from 'ngx-pagination';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css'],
  //changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchResultsComponent implements OnInit {


  @Input() data: Business[] = [];
  @Input() hasSearchRan: boolean = false;

  @Output() onExecuteSearch = new EventEmitter();

  
  
  p: number = 1;

  paginationConfig: PaginationInstance = {
    id: 'custom',
    itemsPerPage: 10,
    currentPage: 1
  };


  constructor() { }

  ngOnInit() {
   
  
  }

  pageChange(value){
    this.paginationConfig.currentPage = value;
    window.scrollTo(0,0);
  }

  executeSearch(){
    this.onExecuteSearch.emit(null);
  }

}
