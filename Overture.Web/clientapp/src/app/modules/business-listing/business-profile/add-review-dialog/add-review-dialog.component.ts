import { AuthenticationService } from '@app/_services/authentication.service';
import { CreateReviewRequest } from '@app/_requests/create-review-request';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, ElementRef, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { ReviewService } from '@app/_services/review.service';
import { NotificationService } from '@app/_services/notification.service';

declare var $:any;

@Component({
  selector: 'app-add-review-dialog',
  templateUrl: './add-review-dialog.component.html',
  styleUrls: ['./add-review-dialog.component.css']
})
export class AddReviewDialogComponent implements OnInit {

  reviewForm: FormGroup;

  @Input() businessId:string;

  @Output() onSave = new EventEmitter();
  @Output() onClose = new EventEmitter();


  @ViewChild('addReviewDialog') dialog:ElementRef; 

  constructor(
    private formBuilder: FormBuilder,
    private el: ElementRef,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private reviewService:ReviewService
  ) { 
    
    // move element to bottom of page (just before </body>) so it can be displayed above everything else
    document.body.appendChild(this.el.nativeElement);
  }

  ngOnInit() {
    this.reviewForm = this.formBuilder.group({
      reviewDate: [''],
      content: [''],
      rating:[0],
      satisfied:[false],
      recommend:[false],
      onTime:[false],
      onBudget:[false]
    })
    
  }

  get reviewDate() { return this.reviewForm.controls.reviewDate; }
  get content() { return this.reviewForm.controls.content; }
  get rating() { return this.reviewForm.controls.rating; }
  get satisfied() { return this.reviewForm.controls.satisfied; }
  get recommend() { return this.reviewForm.controls.recommend; }
  get onTime() { return this.reviewForm.controls.onTime; }
  get onBudget() { return this.reviewForm.controls.onBudget; }

  save(){
    let request = new CreateReviewRequest();
    request.businessId = this.businessId;
    request.reviewer = this.authenticationService.currentUserValue ?  this.authenticationService.currentUserValue.userId : '';
    request.reviewDate = new Date();
    request.content = this.content.value;
    request.recommend = this.recommend.value;
    request.onTime = this.onTime.value;
    request.onBudget = this.onBudget.value;
    request.satisfied = this.satisfied.value;
    request.rating = this.rating.value;
    this.reviewService.create(request).subscribe(
      review => {
        this.notificationService.success('Your changes have been saved.');
        this.onSave.emit();
        this.close();
      }
    )
  }

  clear(){
    this.reviewDate.setValue(null, {onlySelf: true, emitEvent: false});
    this.content.setValue(null, {onlySelf: true, emitEvent: false});
    this.recommend.setValue(null, {onlySelf: true, emitEvent: false});
    this.onTime.setValue(null, {onlySelf: true, emitEvent: false});
    this.onBudget.setValue(null, {onlySelf: true, emitEvent: false});
    this.satisfied.setValue(null, {onlySelf: true, emitEvent: false});
    this.rating.setValue(null, {onlySelf: true, emitEvent: false});
  }

  open(){
    this.clear();
    $.magnificPopup.open({
      type: 'inline',

      items:{
        src:$(this.dialog.nativeElement),
      
        type:'inline'
      },
 
      fixedContentPos: true,
      fixedBgPos: true,
 
      overflowY: 'auto',
 
      closeBtnInside: true,
      preloader: false,
 
      midClick: true,
      removalDelay: 300,
      mainClass: 'my-mfp-zoom-in'
   });
  }

  close(){
    $.magnificPopup.close();
    this.onClose.emit();
  }

}
