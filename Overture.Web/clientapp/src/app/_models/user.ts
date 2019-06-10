import { StoredFile } from './stored-file';

export class User {
  userId:string;
  name:string;
  email:string;
  picture:StoredFile;
  accountType:string;
  accessToken: string;
  idToken: string;
  expiresAt:number;
  
}
