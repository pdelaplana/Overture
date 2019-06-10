import { Job } from '@app/_models/job';
import { UpdateJobRequest } from '@app/_requests/update-job-request';
import { NotificationService } from '@app/_services/notification.service';
import { AuthenticationService } from '@app/_services/authentication.service';
import { JobService } from '@app/_services/job.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, Output, ViewChild, ElementRef, EventEmitter, Input } from '@angular/core';
import { IMyDpOptions } from 'mydatepicker';

declare var $:any;

@Component({
  selector: 'app-edit-job-dialog',
  templateUrl: './edit-job-dialog.component.html',
  styleUrls: ['./edit-job-dialog.component.css']
})
export class EditJobDialogComponent implements OnInit {

  private _id: string;

  jobForm : FormGroup;

  @Input() set id(value:string){
    if (value != undefined){
      this._id = value;
      this.get(value);
      //this.id = value;
      //this.fetchReviews(this.id);  
    }
  };
  @Input() job: Job;

  @Output() onSave = new EventEmitter();
  @Output() onClose = new EventEmitter();

  @ViewChild('editJobDialog') dialog:ElementRef; 

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
    private jobService: JobService
  ) { 
    // move element to bottom of page (just before </body>) so it can be displayed above everything else
    document.body.appendChild(this.el.nativeElement);
  }

  ngOnInit() {
    this.jobForm = this.formBuilder.group({
      title: [''],
      description:[''],
      requiredDate:[''],
    });
  }

  get title() { return this.jobForm.controls.title; }
  get description() { return this.jobForm.controls.description; }
  get requiredDate() { return this.jobForm.controls.requiredDate; }
  
  
  get(id:string){
    this.jobService.get(id).subscribe(
      job => {
        this.requiredDate.setValue({ jsdate : new Date(job.requiredDate) }, {onlySelf: true, emitEvent: false});
        this.title.setValue(job.title, {onlySelf: true, emitEvent: false});
        this.description.setValue(job.description, {onlySelf: true, emitEvent: false});
      }
    )
  }

  save(){
    let request = new UpdateJobRequest();
    request.id = this._id;
    request.requiredDate = this.requiredDate.value.jsdate;
    request.title = this.title.value;
    request.description = this.description.value;
    this.jobService.update(request).subscribe(
      job => {
        this.notificationService.success('Your changes have been saved.');
        this.onSave.emit();
        this.close();
      }
    )
  }

  clear(){
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
