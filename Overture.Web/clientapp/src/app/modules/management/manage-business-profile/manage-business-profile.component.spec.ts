import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageBusinessProfileComponent } from './manage-business-profile.component';

describe('ManageBusinessProfileComponent', () => {
  let component: ManageBusinessProfileComponent;
  let fixture: ComponentFixture<ManageBusinessProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageBusinessProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageBusinessProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
