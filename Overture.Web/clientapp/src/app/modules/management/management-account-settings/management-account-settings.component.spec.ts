import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementAccountSettingsComponent } from './management-account-settings.component';

describe('ManagementAccountSettingsComponent', () => {
  let component: ManagementAccountSettingsComponent;
  let fixture: ComponentFixture<ManagementAccountSettingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagementAccountSettingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagementAccountSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
