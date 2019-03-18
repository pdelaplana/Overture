import { BusinessService } from './../_models/business-service';
import { map } from 'rxjs/operators';
import { ApiResponse } from '@app/_models/api-response';
import { Observable, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusinessServiceService {
  private apiUrl = environment.baseUrl + 'api/services';
  //private data : BehaviorSubject<BusinessService[]> = new BehaviorSubject([]);

  constructor(
    private http:HttpClient
  ) { }

  /*
  get businessServices(){
    let out: BusinessService[];
    this.getBusinessServices().subscribe(services => { 
      out = services;
     } )
     return out;
  }
  */
  getBusinessServices():Observable<BusinessService[]>{
    return this.http.get<ApiResponse>(this.apiUrl )
      .pipe(
        map(result => { return <BusinessService[]>result.data }),
      )
  }


}
