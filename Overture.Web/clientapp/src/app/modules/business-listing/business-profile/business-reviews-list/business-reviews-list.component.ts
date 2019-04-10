import { AddReviewDialogComponent } from './../add-review-dialog/add-review-dialog.component';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { ReviewService } from '@app/_services/review.service';
import { Review } from '@app/_models/review';

@Component({
  selector: 'app-business-reviews-list',
  templateUrl: './business-reviews-list.component.html',
  styleUrls: ['./business-reviews-list.component.css']
})
export class BusinessReviewsListComponent implements OnInit {

  reviews: Review[] = [];
  isUserAuthenticated: boolean = false;
  
  @Input() set businessId(value:string){
    if (value != undefined){
      this.fetchReviews(value);  
    }
  };
  @Output() onAddReview = new EventEmitter()

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

  addReview($event){
    $event.preventDefault();
    this.onAddReview.emit();
  }

}
