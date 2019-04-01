import { TestBed } from '@angular/core/testing';

import { StringFormattingService } from './string-formatting.service';

describe('StringFormattingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StringFormattingService = TestBed.get(StringFormattingService);
    expect(service).toBeTruthy();
  });
});
