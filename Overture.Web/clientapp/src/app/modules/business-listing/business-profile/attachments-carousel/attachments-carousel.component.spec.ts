import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttachmentsCarouselComponent } from './attachments-carousel.component';

describe('AttachmentsCarouselComponent', () => {
  let component: AttachmentsCarouselComponent;
  let fixture: ComponentFixture<AttachmentsCarouselComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttachmentsCarouselComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttachmentsCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
