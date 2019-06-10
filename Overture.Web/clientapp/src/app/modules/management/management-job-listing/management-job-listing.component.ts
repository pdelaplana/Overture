import { EditJobDialogComponent } from './_controls/edit-job-dialog/edit-job-dialog.component';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Job } from '@app/_models/job';
import { JobService } from '@app/_services/job.service';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-management-job-listing',
  templateUrl: './management-job-listing.component.html',
  styleUrls: ['./management-job-listing.component.css']
})
export class ManagementJobListingComponent implements OnInit {

  jobsListing: Job[] = [];

  @ViewChild(EditJobDialogComponent) private editJobDialogComponent:EditJobDialogComponent;

  constructor(
    private jobService:JobService,
    private authenticationService:AuthenticationService
    ) { }

  ngOnInit() {
    this.fetchJobs(this.authenticationService.currentUserValue.userId);
  }


  fetchJobs(userId:string){
    this.jobService.getByUserId(userId).subscribe(
      jobs => {
        this.jobsListing = jobs;
      }
    )
  }

  openEditJobDialog(id:string){
    this.editJobDialogComponent.id = id;
    this.editJobDialogComponent.open();
  }



}
