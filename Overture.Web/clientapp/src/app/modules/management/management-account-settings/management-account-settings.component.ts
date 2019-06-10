import { Observable } from 'rxjs';
import { UpdateUserRequest } from './../../../_requests/update-user-request';
import { AuthenticationService } from '@app/_services/authentication.service';
import { ValidationService } from '@app/_services/validation.service';
import { StoredFile } from '@app/_models/stored-file';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '@app/_services/user.service';
import { NotificationService } from '@app/_services/notification.service';

declare var notifyOnChange: any;
declare var closeNotification: any;


@Component({
  selector: 'app-management-account-settings',
  templateUrl: './management-account-settings.component.html',
  styleUrls: ['./management-account-settings.component.css']
})
export class ManagementAccountSettingsComponent implements OnInit,OnDestroy {
 

  private hasChanges: boolean;
  accountSettingsForm : FormGroup;

  constructor(
    private formBuilder:FormBuilder,
    private userService:UserService,
    private authenticationService:AuthenticationService,
    private notificationService:NotificationService
  ) { }

  ngOnInit() {
    this.accountSettingsForm = this.formBuilder.group({
      userId: [''],
      name: ['', [Validators.required]],
      email: [{value:'', disabled:true}, [Validators.required, Validators.email]],
      accountType: [''],
      picture:[new StoredFile()],
    })

    this.userService.getUserByEmail(this.authenticationService.currentUserValue.email).subscribe( 
      user  => {
        this.userId.setValue(user.userId, {onlySelf: true, emitEvent: false});
        this.name.setValue(user.name, {onlySelf: true, emitEvent: false});
        this.email.setValue(user.email, {onlySelf: true, emitEvent: false});
        this.picture.setValue(user.picture, {onlySelf: true, emitEvent:false});
        this.accountType.setValue(user.accountType, {onlySelf: true, emitEvent:false});
      }
    )

    this.accountSettingsForm.valueChanges.subscribe(val => {
      if(!this.hasChanges){
        let c = this;
        notifyOnChange('You have unsaved changes.',  function() { c.saveChanges(); });
      }
      this.hasChanges = true;
    });
    
  }

  ngOnDestroy(): void {
    closeNotification();
  }

  get userId() { return this.accountSettingsForm.controls.userId; }
  get name() { return this.accountSettingsForm.controls.name; }
  get email() { return this.accountSettingsForm.controls.email; }
  get accountType() { return this.accountSettingsForm.controls.accountType; }
  get picture() { return this.accountSettingsForm.controls.picture; }
  
  saveChanges(){
    let updateUser = new UpdateUserRequest();
    updateUser.userId = this.userId.value;
    updateUser.name = this.name.value;
    updateUser.picture = this.picture.value;
    updateUser.accountType = this.accountType.value;

    this.userService.update(updateUser).subscribe(
      user => {
        this.notificationService.success('Your changes have been saved.');
        this.hasChanges = false;
      }
    )

  }

  addPicture(storedFile: StoredFile){
    this.picture.setValue(storedFile);
  }

  setAccountType(accountType:string){
    this.accountType.setValue(accountType);
  }

  canDeactivate(): Observable<boolean> | boolean { 
    return !this.hasChanges;
  }
}
