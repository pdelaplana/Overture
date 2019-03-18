import { ControlsModule } from './../controls/controls.module';
import { IntroBannerComponent } from './intro-banner/intro-banner.component';
import { HomeComponent } from './home.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PopularCategoriesComponent } from './popular-categories/popular-categories.component';

@NgModule({
  declarations: [
    HomeComponent,
    IntroBannerComponent,
    PopularCategoriesComponent,
  ],
  imports: [
    CommonModule,
    ControlsModule,
  ],
  exports: [
    HomeComponent,
  ]
})
export class HomeModule { }
