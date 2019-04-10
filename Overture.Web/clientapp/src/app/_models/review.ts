export class Review {
  id:string;
  businessId:string;
  businessName:string;
  reviewer:string;
  reviewerName:string;
  reviewDate:Date;
  content:string;
  rating:number;
  satisfied:boolean;
  recommend:boolean;
  onTime:boolean;
  onBudget:boolean;
}
