import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementBusinessProfileComponent } from './management-business-profile.component';

describe('ManagementBusinessProfileComponent', () => {
  let component: ManagementBusinessProfileComponent;
  let fixture: ComponentFixture<ManagementBusinessProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagementBusinessProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagementBusinessProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
