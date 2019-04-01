import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { FileSelectDirective } from 'ng2-file-upload';

import { ControlsModule } from './../_controls/controls.module';
import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';
import { ManagementSidebarComponent } from './management-sidebar/management-sidebar.component';
import { ManagementBusinessProfileComponent } from './management-business-profile/management-business-profile.component';
import { ManagementFooterComponent } from './management-footer/management-footer.component';
import { ManagementAccountSettingsComponent } from './management-account-settings/management-account-settings.component';
import { FileUploadComponent } from './management-business-profile/_controls/file-upload/file-upload.component';
import { PictureUploaderComponent } from './management-business-profile/_controls/picture-uploader/picture-uploader.component';
import { FileUploaderComponent } from './management-business-profile/_controls/file-uploader/file-uploader.component';

@NgModule({
  declarations: [
    ManagementComponent,
    ManagementSidebarComponent,
    ManagementBusinessProfileComponent,
    ManagementFooterComponent,
    ManagementAccountSettingsComponent,
    FileUploadComponent,
    FileSelectDirective,
    PictureUploaderComponent,
    FileUploaderComponent
  ],
  imports: [
    ControlsModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    ManagementRoutingModule
  ]
})
export class ManagementModule { }
