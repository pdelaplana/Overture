import { MyDatePickerModule } from 'mydatepicker';
import { FileUploadModule } from 'ng2-file-upload';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';

import { ControlsModule } from './../_controls/controls.module';
import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';
import { ManagementSidebarComponent } from './management-sidebar/management-sidebar.component';
import { ManagementBusinessProfileComponent } from './management-business-profile/management-business-profile.component';
import { ManagementFooterComponent } from './management-footer/management-footer.component';
import { ManagementAccountSettingsComponent } from './management-account-settings/management-account-settings.component';
import { FileUploadComponent } from './management-business-profile/_controls/file-upload/file-upload.component';
import { FileUploaderComponent } from './management-business-profile/_controls/file-uploader/file-uploader.component';
import { ManagementJobListingComponent } from './management-job-listing/management-job-listing.component';
import { EditJobDialogComponent } from './management-job-listing/_controls/edit-job-dialog/edit-job-dialog.component';

@NgModule({
  declarations: [
    ManagementComponent,
    ManagementSidebarComponent,
    ManagementBusinessProfileComponent,
    ManagementFooterComponent,
    ManagementAccountSettingsComponent,
    FileUploadComponent,
    FileUploaderComponent,
    ManagementJobListingComponent,
    EditJobDialogComponent
  ],
  imports: [
    ControlsModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    MyDatePickerModule,
    ManagementRoutingModule,
    FileUploadModule
  ]
})
export class ManagementModule { }
