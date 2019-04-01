import { ApiResponse } from './../_models/api-response';
import { Business } from './../_models/business';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BusinessListingService {
  private apiUrl: string = environment.baseUrl+'api/businesses';

  selectedCategory: string;

  constructor(
    private http: HttpClient
  ) { }

  
  getBusinesses(services:string[], areas:string[]):Observable<Business[]>{
    return this.http.get<ApiResponse>(this.apiUrl, { params: { services: services, areas: areas }} )
      .pipe(
        map(result => { return <Business[]>result.data }),
      )
  }

}
