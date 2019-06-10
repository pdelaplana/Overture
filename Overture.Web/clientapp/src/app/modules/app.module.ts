import { BusinessListingModule } from './business-listing/business-listing.module';
import { BusinessListingRoutingModule } from './business-listing/business-listing-routing.module';
import { JwtInterceptor } from './../_interceptors/jwt.interceptor';
import { HomeModule } from './home/home.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MomentModule } from 'ngx-moment';
import { HttpErrorInterceptor } from '../_interceptors/http-error.interceptor';

import { ControlsModule } from './_controls/controls.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { ManagementRoutingModule } from './management/management-routing.module';
import { ManagementModule } from './management/management.module';
import { SignInComponent } from './sign-in/sign-in.component';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    SignInComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ControlsModule,
    HomeModule,
    ManagementModule,
    ManagementRoutingModule,
    MomentModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BusinessListingModule,
    BusinessListingRoutingModule
  ],
  exports: [
    
  ],
  providers: [
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: JwtInterceptor, 
      multi: true 
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
