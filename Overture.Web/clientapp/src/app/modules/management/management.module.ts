import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { FileSelectDirective } from 'ng2-file-upload';

import { ControlsModule } from './../controls/controls.module';
import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';
import { ManagementSidebarComponent } from './management-sidebar/management-sidebar.component';
import { ManagementBusinessProfileComponent } from './management-business-profile/management-business-profile.component';
import { ManagementFooterComponent } from './management-footer/management-footer.component';
import { ManagementAccountSettingsComponent } from './management-account-settings/management-account-settings.component';
import { FileUploadComponent } from './management-business-profile/controls/file-upload/file-upload.component';

@NgModule({
  declarations: [
    ManagementComponent,
    ManagementSidebarComponent,
    ManagementBusinessProfileComponent,
    ManagementFooterComponent,
    ManagementAccountSettingsComponent,
    FileUploadComponent,
    FileSelectDirective
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
