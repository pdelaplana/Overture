import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '@app/_guards/auth.guard';
import { ConfirmDeactivateGuard } from '@app/_guards/confirm-deactivate.guard';
import { ManagementAccountSettingsComponent } from './management-account-settings/management-account-settings.component';
import { ManagementComponent } from './management.component';
import { ManagementBusinessProfileComponent } from './management-business-profile/management-business-profile.component';

const managementRoutes: Routes = [
  { path: 'manage', component: ManagementComponent, canActivate: [AuthGuard], //pathMatch: 'full',
    children: [
      {
        path:'', component:ManagementBusinessProfileComponent, canDeactivate:[ConfirmDeactivateGuard]
      },
      {
        path:'business-profile', component:ManagementBusinessProfileComponent, canDeactivate:[ConfirmDeactivateGuard]
      },
      {
        path:'account', component:ManagementAccountSettingsComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(managementRoutes, { enableTracing: false })],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
