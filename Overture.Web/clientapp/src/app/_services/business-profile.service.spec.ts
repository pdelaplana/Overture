import { TestBed } from '@angular/core/testing';

import { BusinessProfileService } from './business-profile.service';

describe('BusinessService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BusinessProfileService = TestBed.get(BusinessProfileService);
    expect(service).toBeTruthy();
  });
});
