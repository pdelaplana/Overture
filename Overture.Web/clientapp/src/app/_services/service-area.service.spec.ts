import { TestBed } from '@angular/core/testing';

import { ServiceAreaService } from './service-area.service';

describe('ServiceAreaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ServiceAreaService = TestBed.get(ServiceAreaService);
    expect(service).toBeTruthy();
  });
});
