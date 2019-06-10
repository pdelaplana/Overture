import { Quote } from './quote';
export class Job {
  id:string;
  userId:string;
  title:string;
  description:string;
  requiredDate:Date;
  expiryDate:Date;
  completedDate:Date;

  quotes: Quote[] = [];
}
