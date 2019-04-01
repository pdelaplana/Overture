import { FileStoreService } from '@app/_services/file-store.service';
import { FileAttachment } from '@app/_models/file-attachment';
import { ApiResponse } from '@app/_models/api-response';
import { FileUploader } from 'ng2-file-upload/ng2-file-upload';
import { AuthenticationService } from '@app/_services/authentication.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-picture-uploader',
  templateUrl: './picture-uploader.component.html',
  styleUrls: ['./picture-uploader.component.css']
})
export class PictureUploaderComponent implements OnInit {
  private apiUrl: string  = environment.baseUrl+'/api/file';
  
  private createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener('load', () => {
       this.picture = reader.result;
    }, false);
 
    if (image) {
       reader.readAsDataURL(image);
       this.hasPicture = true;
    } else{
      this.hasPicture = false;
    }
  }

  private getPicture(fileReference:string){
    if (fileReference != null) {
      this.fileStoreService.get(fileReference).subscribe(result=>{
        this.createImageFromBlob(result);
      })
    }
  }

  @Input() set fileReference(value:string){
    this.getPicture(value);
  };
  @Output() onPictureUploaded = new EventEmitter();

  picture: any;
  hasPicture: boolean = false;

  uploader: FileUploader = new FileUploader({
    url: this.apiUrl, 
    itemAlias: 'file', 
    authToken: 'Bearer ' + this.authenticationService.currentUserValue.accessToken,
   });

  constructor(
    private authenticationService: AuthenticationService,
    private fileStoreService: FileStoreService
  ) { }

  ngOnInit() {
    this.uploader.onAfterAddingFile = (file) => { file.withCredentials = false; };
    this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {
      console.log('ImageUpload:uploaded:', item, status, response);
      let apiResponse: ApiResponse = JSON.parse(response);
      this.onPictureUploaded.emit(<FileAttachment>apiResponse.data);
     };
     
  }

  onFileChange(event){
    this.uploader.uploadAll();
  }

}
