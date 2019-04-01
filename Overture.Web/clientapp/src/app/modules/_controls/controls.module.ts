import { MagnificPopupDirective } from './../../_directives/magnific-popup.directive';
import { PictureComponent } from './picture/picture.component';
import { BootstrapSelectDirective } from './../../_directives/bootstrap-select.directive';
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
import { TippyTooltipsDirective } from '@app/_directives/tippy-tooltips.directive';
import { AttachmentsCarouselDirective } from '@app/_directives/attachments-carousel.directive';
import { ReplacePipe } from '@app/_helpers/replace.pipe';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    BackgroundImageComponent,
    HeaderMessagesComponent,
    HeaderNotificationsComponent,
    HeaderUserMenuComponent,
    RegistrationFormComponent,  
    PictureComponent,
    ReplacePipe,
    BootstrapSelectDirective,
    TippyTooltipsDirective,
    AttachmentsCarouselDirective  ,
    MagnificPopupDirective
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
    RegistrationFormComponent,
    PictureComponent,
    ReplacePipe,
    BootstrapSelectDirective,
    TippyTooltipsDirective,
    AttachmentsCarouselDirective,
    MagnificPopupDirective
  ]
})
export class ControlsModule { }
