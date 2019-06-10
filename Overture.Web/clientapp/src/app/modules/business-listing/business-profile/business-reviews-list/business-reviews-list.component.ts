import { AddReviewDialogComponent } from './../add-review-dialog/add-review-dialog.component';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { ReviewService } from '@app/_services/review.service';
import { Review } from '@app/_models/review';
import { PaginationInstance } from 'ngx-pagination';

@Component({
  selector: 'app-business-reviews-list',
  templateUrl: './business-reviews-list.component.html',
  styleUrls: ['./business-reviews-list.component.css']
})
export class BusinessReviewsListComponent implements OnInit {

  id: string;
  reviews: Review[] = [];
  isUserAuthenticated: boolean = false;
  
  @Input() set businessId(value:string){
    if (value != undefined){
      this.id = value;
      this.fetchReviews(this.id);  
    }
  };
  @Output() onOpenReviewDialog = new EventEmitter();

  p: number = 1;

  paginationConfig: PaginationInstance = {
    id: 'custom',
    itemsPerPage: 5,
    currentPage: 1
  };

  pageChange(value){
    this.paginationConfig.currentPage = value;
    window.scrollTo(0,0);
  }

  constructor(
    private authenticationService:AuthenticationService,
    private reviewService:ReviewService
  ) { }

  ngOnInit() {
    this.isUserAuthenticated = this.authenticationService.isUserAuthenticated;
  }

  fetchReviews(id:string){
    this.reviewService.getByBusiness(id)
    .subscribe( reviews => { 
      this.reviews = reviews;
    })
  }

  openReviewDialog($event){
    this.onOpenReviewDialog.emit();
  }

}
