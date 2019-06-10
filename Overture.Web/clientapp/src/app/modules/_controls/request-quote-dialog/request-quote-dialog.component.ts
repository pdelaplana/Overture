import { QuoteService } from '@app/_services/quote.service';
import { JobService } from '@app/_services/job.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Component, OnInit, Output, EventEmitter, ViewChild, ElementRef, Input } from '@angular/core';
import { IMyDpOptions, IMyDateModel } from 'mydatepicker';
import { NotificationService } from '@app/_services/notification.service';
import { RequestQuoteRequest } from '@app/_requests/request-quote-request';

declare var $:any;

@Component({
  selector: 'app-request-quote-dialog',
  templateUrl: './request-quote-dialog.component.html',
  styleUrls: ['./request-quote-dialog.component.css']
})
export class RequestQuoteDialogComponent implements OnInit {

  jobForm : FormGroup;
  isUserAuthenticated: boolean;

  @Input() businessId:string;
  @Input() businessOwner:string;

  @Output() onSave = new EventEmitter();
  @Output() onClose = new EventEmitter();

  @ViewChild('requestQuoteDialog') dialog:ElementRef; 

  myDatePickerOptions: IMyDpOptions = {
    // other options...
    dateFormat: 'dd mmm yyyy',
    showSelectorArrow: false,
    editableDateField:false

  };


  constructor(
    private formBuilder: FormBuilder,
    private el: ElementRef,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private quoteService: QuoteService
  ) { 
    // move element to bottom of page (just before </body>) so it can be displayed above everything else
    document.body.appendChild(this.el.nativeElement); 
  }

  ngOnInit() {
    this.isUserAuthenticated = this.authenticationService.isUserAuthenticated;
    this.jobForm = this.formBuilder.group({
      name: [''],
      email: [''],
      title: [''],
      description:[''],
      requiredDate:[''],
    });
  }

  get name() { return this.jobForm.controls.name; }
  get email() { return this.jobForm.controls.email; }
  get title() { return this.jobForm.controls.title; }
  get description() { return this.jobForm.controls.description; }
  get requiredDate() { return this.jobForm.controls.requiredDate; }
  
  
  save(){
    let request = new RequestQuoteRequest();
    if (this.isUserAuthenticated){
      request.email = this.authenticationService.currentUserValue ?  this.authenticationService.currentUserValue.email : '';
    } else {
      request.name = this.name.value;
      request.email = this.email.value;
    }
    request.businessId =this.businessId;
    request.requiredDate = this.requiredDate.value.jsdate;
    request.title = this.title.value;
    request.description = this.description.value;
    this.quoteService.create(request).subscribe(
      job => {
        this.notificationService.success('Your request have been submitted.');
        this.onSave.emit();
        this.close();
      }
    )
  }

  clear(){
    this.name.setValue(null, {onlySelf: true, emitEvent: false});
    this.email.setValue(null, {onlySelf: true, emitEvent: false});
    this.requiredDate.setValue(null, {onlySelf: true, emitEvent: false});
    this.title.setValue(null, {onlySelf: true, emitEvent: false});
    this.description.setValue(null, {onlySelf: true, emitEvent: false});
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
