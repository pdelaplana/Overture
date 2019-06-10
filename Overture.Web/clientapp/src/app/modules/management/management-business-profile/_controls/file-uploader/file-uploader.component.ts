import { StoredFile } from '@app/_models/stored-file';
import { ApiResponse } from '@app/_models/api-response';
import { AuthenticationService } from '@app/_services/authentication.service';
import { FileUploader } from 'ng2-file-upload/ng2-file-upload';
import { Component, OnInit, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css']
})
export class FileUploaderComponent implements OnInit {
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
