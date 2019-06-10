import { ApiResponse } from '@app/_models/api-response';
import { Job } from './../_models/job';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { RequestQuoteRequest } from '@app/_requests/request-quote-request';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  private apiUrl = environment.baseUrl + 'api/quotes';

  constructor(private http:HttpClient) {

  }

  create(request:RequestQuoteRequest):Observable<Job>{
    return this.http.post<ApiResponse>(this.apiUrl, request )
      .pipe(
        map(result => { return <Job>result.data }),
      )
  }

}
