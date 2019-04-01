import { ApiResponse } from './../_models/api-response';
import { BusinessService } from './../_models/business-service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { map } from 'rxjs/operators';
import { ServiceArea } from '@app/_models/service-area';

@Injectable({
  providedIn: 'root'
})
export class ReferenceDataService {

  constructor(
    private http: HttpClient
  ) { }


  getBusinessServices():Observable<BusinessService[]>{
    let apiUrl : string =  environment.baseUrl + 'api/services'; 
    return this.http.get<ApiResponse>(apiUrl)
      .pipe(
        map(result => { return <BusinessService[]>result.data }),
      )
  }

  getServiceAreas():Observable<ServiceArea[]>{
    let apiUrl : string =  environment.baseUrl + 'api/service_areas';
    return this.http.get<ApiResponse>(apiUrl )
      .pipe(
        map(result => { return <ServiceArea[]>result.data }),
      )
  }

}
