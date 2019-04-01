import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessReviewsListComponent } from './business-reviews-list.component';

describe('BusinesssReviewsListComponent', () => {
  let component: BusinessReviewsListComponent;
  let fixture: ComponentFixture<BusinessReviewsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusinessReviewsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessReviewsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
