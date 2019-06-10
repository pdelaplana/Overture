import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestQuoteDialogComponent } from './request-quote-dialog.component';

describe('RequestQuoteDialogComponent', () => {
  let component: RequestQuoteDialogComponent;
  let fixture: ComponentFixture<RequestQuoteDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestQuoteDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestQuoteDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
