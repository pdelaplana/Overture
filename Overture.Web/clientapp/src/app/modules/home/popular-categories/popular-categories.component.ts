import { Component, OnInit } from '@angular/core';

import { BusinessServiceCategoryService } from '@app/_services/business-service-category.service';
import { BusinessServiceCategory } from '@app/_models/business-service-category';

@Component({
  selector: 'app-popular-categories',
  templateUrl: './popular-categories.component.html',
  styleUrls: ['./popular-categories.component.css']
})
export class PopularCategoriesComponent implements OnInit {
  private categories: BusinessServiceCategory[];

  constructor(
    private businessServiceCategoryService: BusinessServiceCategoryService) { }

  ngOnInit() {
    this.getBusinessServiceCategories();
  }

  getBusinessServiceCategories(): void {
    this.businessServiceCategoryService.getTopTen()
      .subscribe(categories => this.categories = categories);
  }

}
