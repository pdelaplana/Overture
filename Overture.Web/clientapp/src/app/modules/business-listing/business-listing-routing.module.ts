import { BusinessProfileComponent } from './business-profile/business-profile.component';
import { BusinessListingComponent } from './business-listing.component';
import { BusinessListingHomeComponent } from './business-listing-home/business-listing-home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const businessListingRoutes: Routes = [
  { path: 'business-listing', component: BusinessListingComponent, //pathMatch: 'full',
    children: [
      {
        path:'', component:BusinessListingHomeComponent,
      },
      {
        path:':cat', component:BusinessListingHomeComponent,
      },
      {
        path:'profile/:altReference', component:BusinessProfileComponent,
      },
      
      /*
      {
        path:'business-profile', component:ManagementBusinessProfileComponent, canDeactivate:[ConfirmDeactivateGuard]
      },
      {
        path:'account', component:ManagementAccountSettingsComponent
      }
      */
    ]
  },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(businessListingRoutes, { enableTracing: false, scrollPositionRestoration: 'enabled' })
  ],
  exports:[RouterModule]
})
export class BusinessListingRoutingModule { }
