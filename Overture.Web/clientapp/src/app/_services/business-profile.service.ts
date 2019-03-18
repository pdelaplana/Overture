import { ApiResponse } from '../_models/api-response';
import { Business } from '../_models/business';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BusinessProfileService {
  private url = environment.baseUrl + 'api/business';

  constructor(
    private http:HttpClient
  ) { }

  getByUserId(userId:string):Observable<Business>{

    return this.http.get<ApiResponse>(this.url, { params: { userId: userId }} )
      .pipe(
        map(result => { return <Business>result.data }),
      )
  }

  update(business:Business):Observable<Business>{
    return this.http.put<ApiResponse>(this.url, business)
    .pipe(
      map(result => {
        if (result.data){
          return <Business>result.data;
        } else {
          return null;
        }
      })
    )
  }

}
