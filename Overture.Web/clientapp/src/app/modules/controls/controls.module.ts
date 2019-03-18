import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MomentModule } from 'ngx-moment';
import { AppRoutingModule } from '../app-routing.module';
import { HeaderUserMenuComponent } from './header/header-user-menu/header-user-menu.component';
import { HeaderNotificationsComponent } from './header/header-notifications/header-notifications.component';
import { HeaderMessagesComponent } from './header/header-messages/header-messages.component';
import { BackgroundImageComponent } from './background-image/background-image.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { ManagementRoutingModule } from '@app/modules/management/management-routing.module';
import { RegistrationFormComponent } from './registration-form/registration-form.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    BackgroundImageComponent,
    HeaderMessagesComponent,
    HeaderNotificationsComponent,
    HeaderUserMenuComponent,
    RegistrationFormComponent,    
  ],
  imports: [
    CommonModule,
    MomentModule,
    AppRoutingModule,
    ManagementRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    BackgroundImageComponent,
    RegistrationFormComponent
  ]
})
export class ControlsModule { }
