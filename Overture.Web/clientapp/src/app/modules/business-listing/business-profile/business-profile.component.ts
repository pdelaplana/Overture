import { BusinessReviewsListComponent } from './business-reviews-list/business-reviews-list.component';
import { AddReviewDialogComponent } from './add-review-dialog/add-review-dialog.component';
import { AuthenticationService } from './../../../_services/authentication.service';
import { Business } from '@app/_models/business';
import { BusinessProfileService } from '@app/_services/business-profile.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { RequestQuoteDialogComponent } from '@app/modules/_controls/request-quote-dialog/request-quote-dialog.component';


@Component({
  selector: 'app-business-profile',
  templateUrl: './business-profile.component.html',
  styleUrls: ['./business-profile.component.css']
})
export class BusinessProfileComponent implements OnInit {

  business: Business = new Business();

  isUserAuthenticated: boolean = false;

  @ViewChild(AddReviewDialogComponent) private addReviewDialog:AddReviewDialogComponent;
  @ViewChild(BusinessReviewsListComponent) private reviewsList:BusinessReviewsListComponent;
  @ViewChild(RequestQuoteDialogComponent) private requestQuoteDialog:RequestQuoteDialogComponent;

  constructor(
    private route:ActivatedRoute,
    private businessProfileService: BusinessProfileService,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.isUserAuthenticated = this.authenticationService.isUserAuthenticated;

    let altReference = this.route.snapshot.params.altReference;
    if (altReference){
      this.businessProfileService.getByAltReference(altReference).subscribe(profile=> {
        this.business = profile;
      })      
    }
  }

  openReviewDialog(){
    this.addReviewDialog.open();
  }

  openRequestQuoteDialog(){
    this.requestQuoteDialog.open();
  }

  reviewAdded($event){
    this.reviewsList.fetchReviews(this.business.id);
  }
 


}
