import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ControlsModule } from './../controls/controls.module';
import { ManagementComponent } from './management.component';
import { ManagementRoutingModule } from './management-routing.module';
import { ManageBusinessProfileComponent } from './manage-business-profile/manage-business-profile.component';
import { ManagementSidebarComponent } from './management-sidebar/management-sidebar.component';
import { ManagementBusinessProfileComponent } from './management-business-profile/management-business-profile.component';
import { ManagementFooterComponent } from './management-footer/management-footer.component';
import { ManagementAccountSettingsComponent } from './management-account-settings/management-account-settings.component';

@NgModule({
  declarations: [
    ManagementComponent,
    ManageBusinessProfileComponent,
    ManagementSidebarComponent,
    ManagementBusinessProfileComponent,
    ManagementFooterComponent,
    ManagementAccountSettingsComponent
  ],
  imports: [
    ControlsModule,
    CommonModule,
    ManagementRoutingModule
  ]
})
export class ManagementModule { }
