export class CreateReviewRequest {
  businessId:string;
  reviewer:string;
  reviewDate:Date;
  content:string;
  satisfied:boolean;
  recommend:boolean;
  rehire:boolean;
  onTime:boolean;
  onBudget:boolean;
  rating:number;
}
