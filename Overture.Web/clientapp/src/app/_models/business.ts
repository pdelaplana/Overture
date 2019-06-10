import { BusinessRatings } from './business-ratings';
import { StoredFile } from '@app/_models/stored-file';
import { Address } from './address';
import { ServiceArea } from './service-area';
import { BusinessService } from './business-service';
import { ContactMethod } from './contact-method';
export class Business {
  id: string;
  name: string;
  altReference:string;
  owner: string;
  tagline: string;
  description: string;
  isTrading: boolean;
  picture: StoredFile;
  address: Address;
  serviceAreas: ServiceArea[];
  businessServices: BusinessService[];
  contactMethods: ContactMethod[];
  storedFiles:StoredFile[];
  ratings:BusinessRatings;
  constructor(){
    this.ratings = new BusinessRatings();
  }
}
