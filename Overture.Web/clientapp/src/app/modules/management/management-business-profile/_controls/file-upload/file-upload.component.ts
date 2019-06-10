import { ApiResponse } from '@app/_models/api-response';
import { StoredFile } from '@app/_models/stored-file';
import { Component, OnInit, ChangeDetectorRef, Output, EventEmitter } from '@angular/core';
import { FileUploader, FileSelectDirective } from 'ng2-file-upload/ng2-file-upload';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from '@app/_services/authentication.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {
  private apiUrl: string  = environment.baseUrl+'/api/file'

  @Output() onFileUploaded = new EventEmitter();

  uploader: FileUploader = new FileUploader({
    url: this.apiUrl, 
    itemAlias: 'file', 
    authToken: 'Bearer ' + this.authenticationService.currentUserValue.accessToken,
    
    additionalParameter: {
      id: 'test'
    }
   });



  constructor(
    private cd: ChangeDetectorRef,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit() {
    this.uploader.onAfterAddingFile = (file) => { file.withCredentials = false; };
    this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {
      console.log('ImageUpload:uploaded:', item, status, response);
      let apiResponse: ApiResponse = JSON.parse(response);
      this.onFileUploaded.emit(<StoredFile>apiResponse.data);
     };
  }

 

  onFileChange(event){
    this.uploader.uploadAll();
    /*
    let reader = new FileReader();
 
    if(event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);
    
      reader.onload = () => {
              
        // need to run CD since file load runs outside of zone
        this.cd.markForCheck();
      };
    }
    */
  }



}
