import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import {NgxPaginationModule} from 'ngx-pagination'
import { SlickCarouselModule } from 'ngx-slick-carousel';

import { ControlsModule } from './../_controls/controls.module';
import { BusinessListingRoutingModule } from './business-listing-routing.module';
import { BusinessListingHomeComponent } from './business-listing-home/business-listing-home.component';
import { BusinessListingComponent } from './business-listing.component';
import { SearchControlPanelComponent } from './business-listing-home/search-control-panel/search-control-panel.component';

import { SearchResultsComponent } from './business-listing-home/search-results/search-results.component';
import { BusinessProfileComponent } from './business-profile/business-profile.component';
import { BusinessReviewsListComponent } from './business-profile/business-reviews-list/business-reviews-list.component';
import { AttachmentsCarouselComponent } from './business-profile/attachments-carousel/attachments-carousel.component';

@NgModule({
  declarations: [
    BusinessListingHomeComponent,
    BusinessListingComponent,
    SearchControlPanelComponent,
    SearchResultsComponent,
    BusinessProfileComponent,
    BusinessReviewsListComponent,
    AttachmentsCarouselComponent
  ],
  imports: [
    CommonModule,
    ControlsModule,
    NgSelectModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    SlickCarouselModule,
    BusinessListingRoutingModule,
    
  ]
})
export class BusinessListingModule { }
