import { map } from 'rxjs/operators';
import { ApiResponse } from '@app/_models/api-response';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { ServiceArea } from '@app/_models/service-area';

@Injectable({
  providedIn: 'root'
})
export class ServiceAreaService {
  private apiUrl = environment.baseUrl + 'api/service_areas';

  constructor(
    private http: HttpClient
  ) { }

  getServiceAreas():Observable<ServiceArea[]>{
    return this.http.get<ApiResponse>(this.apiUrl )
      .pipe(
        map(result => { return <ServiceArea[]>result.data }),
      )
  }
}

