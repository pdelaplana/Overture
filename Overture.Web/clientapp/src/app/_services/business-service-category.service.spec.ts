import { TestBed } from '@angular/core/testing';

import { BusinessServiceCategoryService } from './business-service-category.service';

describe('BusinessServiceCategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BusinessServiceCategoryService = TestBed.get(BusinessServiceCategoryService);
    expect(service).toBeTruthy();
  });
});
