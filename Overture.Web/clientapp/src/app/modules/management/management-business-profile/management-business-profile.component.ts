import { AddReviewDialogComponent } from './../../business-listing/business-profile/add-review-dialog/add-review-dialog.component';
import { ReferenceDataService } from '@app/_services/reference-data.service';
import { FileStoreService } from './../../../_services/file-store.service';
import { StoredFile } from '../../../_models/stored-file';
import { NotificationService } from '@app/_services/notification.service';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Business } from '@app/_models/business';
import { BusinessService } from '@app/_models/business-service';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { BusinessProfileService } from '@app/_services/business-profile.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ContactMethod } from '@app/_models/contact-method';
import { Address } from '@app/_models/address';
import { ServiceArea } from '@app/_models/service-area';
import { Observable } from 'rxjs';

declare var notifyOnChange: any;
declare var closeNotification: any;

@Component({
  selector: 'app-management-business-profile',
  templateUrl: './management-business-profile.component.html',
  styleUrls: ['./management-business-profile.component.css']
})
export class ManagementBusinessProfileComponent implements OnInit, OnDestroy {
  private userId : string;
  private id : string;
  
  businessProfile : Business;
  businessProfileForm: FormGroup;
  hasChanges: boolean = false;

  dataSources : {
    businessServices: BusinessService[],
    serviceAreas: ServiceArea[]
  } = { businessServices: [], serviceAreas: [] } 
  
  
  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private businessProfileService:BusinessProfileService,
    private referenceDataService: ReferenceDataService,
    private fileStoreService: FileStoreService,
    private notificationService: NotificationService
    ) { }

  ngOnInit() {
    this.referenceDataService.getBusinessServices().subscribe(services => { this.dataSources.businessServices = services });
    this.referenceDataService.getServiceAreas().subscribe(areas => {  this.dataSources.serviceAreas = areas  })
    this.userId = this.authenticationService.currentUserValue.userId;
    this.businessProfileForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      owner: ['', [Validators.required]],
      tagline: ['', [Validators.required]],
      description: ['', [Validators.required]],
      picture:[new StoredFile()],
      isTrading: [false],
      serviceAreas: [],
      services: [],
      storedFiles: [],
      phone: [],
      email: ['', [Validators.email]],
      twitter: [],
      facebook: [],
      instagram: [],
      linkedIn: [],
      streetAddress1: [],
      streetAddress2: [],
      streetAddress3:[],
      cityTownOrSuburb: [],
      stateRegionOrProvince: [],
      countryName: [],
      postCode: []
    })
    
    this.businessProfileService.getByUserId(this.userId)
      .subscribe(businessProfile => {
        if (businessProfile == null) return;

        this.id = businessProfile.id;
        this.name.setValue(businessProfile.name, {onlySelf: true, emitEvent: false});
        this.owner.setValue(businessProfile.owner, {onlySelf: true, emitEvent: false});
        this.tagline.setValue(businessProfile.tagline, {onlySelf: true, emitEvent: false});
        this.description.setValue(businessProfile.description, {onlySelf: true, emitEvent: false});
        this.picture.setValue(businessProfile.picture, {onlySelf: true, emitEvent: false});
        this.isTrading.setValue(businessProfile.isTrading, {onlySelf: true, emitEvent: false});
        this.serviceAreas.setValue(businessProfile.serviceAreas, {onlySelf: true, emitEvent: false});
        this.services.setValue(businessProfile.businessServices, {onlySelf: true, emitEvent: false});
        this.storedFiles.setValue(businessProfile.storedFiles, {onlySelf: true, emitEvent: false});
        this.streetAddress1.setValue(businessProfile.address.streetAddress1, {onlySelf: true, emitEvent: false});
        this.streetAddress2.setValue(businessProfile.address.streetAddress2, {onlySelf: true, emitEvent: false});
        this.streetAddress3.setValue(businessProfile.address.streetAddress3, {onlySelf: true, emitEvent: false});
        this.cityTownOrSuburb.setValue(businessProfile.address.cityTownOrSuburb, {onlySelf: true, emitEvent: false});
        this.stateRegionOrProvince.setValue(businessProfile.address.stateRegionOrProvince, {onlySelf: true, emitEvent: false});
        this.countryName.setValue(businessProfile.address.countryName, {onlySelf: true, emitEvent: false});
        this.postCode.setValue(businessProfile.address.postCode, {onlySelf: true, emitEvent: false});
        this.phone.setValue(businessProfile.contactMethods.find(contactMethod => contactMethod.type == 'Phone').value, {onlySelf: true, emitEvent: false});
        this.email.setValue(businessProfile.contactMethods.find(contactMethod => contactMethod.type == 'Email').value, {onlySelf: true, emitEvent: false});
        this.facebook.setValue(businessProfile.contactMethods.find(contactMethod => contactMethod.type == 'Facebook').value, {onlySelf: true, emitEvent: false});
        this.twitter.setValue(businessProfile.contactMethods.find(contactMethod => contactMethod.type == 'Twitter').value, {onlySelf: true, emitEvent: false});
        this.instagram.setValue(businessProfile.contactMethods.find(contactMethod => contactMethod.type == 'Instagram').value, {onlySelf: true, emitEvent: false});
        this.linkedIn.setValue(businessProfile.contactMethods.find(contactMethod => contactMethod.type == 'LinkedIn').value, {onlySelf: true, emitEvent: false});
      });

    this.businessProfileForm.valueChanges.subscribe(val => {
      if(!this.hasChanges){
        let c = this;
        notifyOnChange('You have unsaved changes.',  function() { c.saveChanges(); });
      }
      this.hasChanges = true;
    });
    
  }

  ngOnDestroy(){
    closeNotification();
  }

  get name() { return this.businessProfileForm.controls.name; }
  get owner() { return this.businessProfileForm.controls.owner; }
  get tagline() { return this.businessProfileForm.controls.tagline; }
  get description() { return this.businessProfileForm.controls.description; }
  get picture() { return this.businessProfileForm.controls.picture; }
  get isTrading() { return this.businessProfileForm.controls.isTrading; }  
  get serviceAreas() { return this.businessProfileForm.controls.serviceAreas; }
  get services() { return this.businessProfileForm.controls.services; }
  get storedFiles() { return this.businessProfileForm.controls.storedFiles; }
  get phone() { return this.businessProfileForm.controls.phone; }
  get email() { return this.businessProfileForm.controls.email; }
  get twitter() { return this.businessProfileForm.controls.twitter; }
  get facebook() { return this.businessProfileForm.controls.facebook; }
  get instagram() { return this.businessProfileForm.controls.instagram; }
  get linkedIn() { return this.businessProfileForm.controls.linkedIn; }
  get streetAddress1() { return this.businessProfileForm.controls.streetAddress1; }
  get streetAddress2() { return this.businessProfileForm.controls.streetAddress2; }
  get streetAddress3() { return this.businessProfileForm.controls.streetAddress3; }
  get cityTownOrSuburb() { return this.businessProfileForm.controls.cityTownOrSuburb; }
  get stateRegionOrProvince() { return this.businessProfileForm.controls.stateRegionOrProvince; }
  get countryName() { return this.businessProfileForm.controls.countryName; }
  get postCode() { return this.businessProfileForm.controls.postCode; }

  private createContactMethod(type:string, value:any){
    let contactMethod = new ContactMethod();
    contactMethod.type = type;
    contactMethod.value = value;
    return contactMethod;
  }

  enableProfile(enable:boolean){
    this.isTrading.setValue(enable);
  }


  saveChanges() {
    let business = new Business();
    business.id = this.id;
    business.name = this.name.value;
    business.owner = this.owner.value;
    business.description = this.description.value;
    business.tagline = this.tagline.value;
    business.picture = this.picture.value;
    business.isTrading = this.isTrading.value;
    business.serviceAreas = this.serviceAreas.value
    business.businessServices = this.services.value;

    // address
    business.address = new Address();
    business.address.streetAddress1 = this.streetAddress1.value;
    business.address.streetAddress2 = this.streetAddress2.value;
    business.address.streetAddress3 = this.streetAddress3.value;
    business.address.cityTownOrSuburb = this.cityTownOrSuburb.value;
    business.address.stateRegionOrProvince = this.stateRegionOrProvince.value;
    business.address.countryName = this.countryName.value;
    business.address.postCode = this.postCode.value;
    
    // contact methods
    business.contactMethods = new Array();
    business.contactMethods.push(this.createContactMethod('Phone', this.phone.value));
    business.contactMethods.push(this.createContactMethod('Email', this.email.value));
    business.contactMethods.push(this.createContactMethod('Facebook', this.facebook.value));
    business.contactMethods.push(this.createContactMethod('Instagram', this.instagram.value));
    business.contactMethods.push(this.createContactMethod('Twitter', this.twitter.value));
    business.contactMethods.push(this.createContactMethod('LinkedIn', this.linkedIn.value));

    business.storedFiles = this.storedFiles.value;

    this.businessProfileService.update(business).subscribe(
      business => {
        this.notificationService.success('Your changes have been saved.');
        this.hasChanges = false;
      }
    );
  }

  onFileChange(event) {
    //this.uploadStatus = 0;
    if (event.target.files.length > 0) {
      let file = event.target.files[0];
      //this.form.get('bannedList').setValue(file);
    }

  }

  addStoredFile(StoredFile: StoredFile){
    let files = this.storedFiles.value;
    files.push(StoredFile);
    this.storedFiles.setValue(files);
  }

  deleteStoredFile(fileReference:string){
    this.fileStoreService.delete(fileReference).subscribe(
      result => {
        if (result){
          let files : StoredFile[] = this.storedFiles.value;
          files = files.filter(f => f.fileReference!=fileReference);
          this.storedFiles.setValue(files);
        }
      }
    )
  }

  addPicture(storedFile: StoredFile){
    this.picture.setValue(storedFile);
  }

  canDeactivate(): Observable<boolean> | boolean { 
    return !this.hasChanges;
  }
}
