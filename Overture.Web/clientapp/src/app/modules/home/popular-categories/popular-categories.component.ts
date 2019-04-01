import { Component, OnInit } from '@angular/core';

import { BusinessServiceCategoryService } from '@app/_services/business-service-category.service';
import { BusinessServiceCategory } from '@app/_models/business-service-category';
import { Router } from '@angular/router';
import { ComponentMessagingService } from '@app/_services/component-messaging.service';
import { SearchParametersMessage } from '@app/_messages/search-parameters.message';

@Component({
  selector: 'app-popular-categories',
  templateUrl: './popular-categories.component.html',
  styleUrls: ['./popular-categories.component.css']
})
export class PopularCategoriesComponent implements OnInit {
  private categories: BusinessServiceCategory[];

  constructor(
    private messagingService : ComponentMessagingService,
    private businessServiceCategoryService: BusinessServiceCategoryService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.getBusinessServiceCategories();
  }

  getBusinessServiceCategories(): void {
    this.businessServiceCategoryService.getTopTen()
      .subscribe(categories => this.categories = categories);
  }

  openBusinessListing(category:string){
    let params = new SearchParametersMessage();
    params.selectedCategories.push(category);
    
    this.messagingService.sendMessage(params);
    this.router.navigate(['/business-listing']);
  }

}
