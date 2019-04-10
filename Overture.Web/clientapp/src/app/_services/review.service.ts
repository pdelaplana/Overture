import { CreateReviewRequest } from './../_requests/create-review-request';
import { Review } from './../_models/review';
import { ApiResponse } from '@app/_models/api-response';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  private apiUrl = environment.baseUrl + 'api/reviews';

  constructor(
    private http:HttpClient
  ) { }

  create(request:CreateReviewRequest):Observable<Review>{
    return this.http.post<ApiResponse>(this.apiUrl, request )
      .pipe(
        map(result => { return <Review>result.data }),
      )
  }

  update(){

  }

  getByBusiness(id:string):Observable<Review[]>{
    return this.http.get<ApiResponse>(this.apiUrl, { params: { businessId: id }} )
    .pipe(
      map(result => { return <Review[]>result.data }),
    )
  }

}
