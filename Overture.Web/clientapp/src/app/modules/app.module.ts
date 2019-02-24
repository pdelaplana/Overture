import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MomentModule } from 'ngx-moment';

import { HttpErrorInterceptor } from '../_interceptors/http-error-interceptor';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { IntroBannerComponent } from './home/intro-banner/intro-banner.component';
import { PopularCategoriesComponent } from './home/popular-categories/popular-categories.component';
import { RegisterComponent } from './register/register.component';
import { ManagementRoutingModule } from './management/management-routing.module';
import { ManagementModule } from './management/management.module';
import { ControlsModule } from './controls/controls.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    IntroBannerComponent,
    PopularCategoriesComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ControlsModule,
    ManagementModule,
    ManagementRoutingModule,
    MomentModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
