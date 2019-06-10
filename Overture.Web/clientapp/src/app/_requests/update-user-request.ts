import { StoredFile } from '@app/_models/stored-file';
export class UpdateUserRequest {
  userId:string;
  name:string;
  picture:StoredFile;
  accountType:string;
}
