import { Observable } from 'rxjs';
import { ComponentMessagingService } from '@app/_services/component-messaging.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Business } from '@app/_models/business';
import { BusinessListingService } from '@app/_services/business-listing.service';
import { Component, OnInit } from '@angular/core';
import { SelectorContext } from '@angular/compiler';
import { ServiceArea } from '@app/_models/service-area';
import { SearchParametersMessage } from '@app/_messages/search-parameters.message';

@Component({
  selector: 'app-business-listing-home',
  templateUrl: './business-listing-home.component.html',
  styleUrls: ['./business-listing-home.component.css']
})
export class BusinessListingHomeComponent implements OnInit {
  private selectedServices : string[] = [];
  private selectedAreas : string[] = [];
  private selectedCategories : string[] = [];
  
  searchHasRan: boolean = false;

  businesses:Business[] = [];
  

  constructor(
    private route: ActivatedRoute,
    private messagingService: ComponentMessagingService,
    private businessListingService: BusinessListingService
  ) { }

  ngOnInit() {
    // check if there is a message to run the search with params
    this.messagingService.currentMessage.subscribe(message => {
      if (message instanceof SearchParametersMessage){
        this.selectedCategories = message.selectedCategories;
      }
    })
    this.route.params.forEach(
      (params : Params) => {
        if (params != null){
          if (params['cat']){
            this.selectedCategories.push(params['cat']);
          }
        }
      }
   );

  }

  executeSearch(){
    this.businessListingService.getBusinesses(this.selectedServices, this.selectedAreas)
      .subscribe( businesses => { 
        this.businesses = businesses;
        this.searchHasRan = true;
      })
  }


  changeServicesCriteria(services:string[]){
    this.selectedServices = services;
    this.executeSearch();
  }

  changeAreasCriteria(areas:string[]){
    this.selectedAreas = areas;
    this.executeSearch();

  }


}
