import { FileStoreService } from '@app/_services/file-store.service';
import { Component, OnInit, Input } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NOT_FOUND_CHECK_ONLY_ELEMENT_INJECTOR } from '@angular/core/src/view/provider';

@Component({
  selector: 'app-picture',
  templateUrl: './picture.component.html',
  styleUrls: ['./picture.component.css']
})
export class PictureComponent implements OnInit {

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

  @Input() maxHeight:any = null;
  @Input() maxWidth:any= null;

  picture: any;
  hasPicture: boolean = false;
 

  constructor(private fileStoreService: FileStoreService) { }

  ngOnInit() {
    //this.getPicture();
  }

}
