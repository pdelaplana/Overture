import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchControlPanelComponent } from './search-control-panel.component';

describe('SearchControlPanelComponent', () => {
  let component: SearchControlPanelComponent;
  let fixture: ComponentFixture<SearchControlPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchControlPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchControlPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
