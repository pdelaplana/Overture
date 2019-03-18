import { FileAttachment } from './file-attachment';
import { Address } from './address';
import { ServiceArea } from './service-area';
import { BusinessService } from './business-service';
import { ContactMethod } from './contact-method';
export class Business {
  id: string;
  name: string;
  owner: string;
  tagline: string;
  description: string;
  isTrading: boolean;
  address: Address;
  serviceAreas: ServiceArea[];
  businessServices: BusinessService[];
  contactMethods: ContactMethod[];
  fileAttachments: FileAttachment[];
}
