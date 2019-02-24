import { ManagementAccountSettingsComponent } from './management-account-settings/management-account-settings.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManagementComponent } from './management.component';
import { ManagementBusinessProfileComponent } from './management-business-profile/management-business-profile.component';

const managementRoutes: Routes = [
  { path: 'manage', component: ManagementComponent, //pathMatch: 'full',
    children: [
      {
        path:'', component:ManagementBusinessProfileComponent
      },
      {
        path:'business-profile', component:ManagementBusinessProfileComponent
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
