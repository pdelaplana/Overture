import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementJobListingComponent } from './management-job-listing.component';

describe('ManagementJobListingComponent', () => {
  let component: ManagementJobListingComponent;
  let fixture: ComponentFixture<ManagementJobListingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagementJobListingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagementJobListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
