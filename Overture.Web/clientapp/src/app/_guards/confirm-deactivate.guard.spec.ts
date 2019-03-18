import { TestBed, async, inject } from '@angular/core/testing';

import { ConfirmDeactivateGuard } from './confirm-deactivate.guard';

describe('ConfirmDeactivateGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfirmDeactivateGuard]
    });
  });

  it('should ...', inject([ConfirmDeactivateGuard], (guard: ConfirmDeactivateGuard) => {
    expect(guard).toBeTruthy();
  }));
});
