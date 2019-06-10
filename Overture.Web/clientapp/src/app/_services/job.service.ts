import { map } from 'rxjs/operators';
import { ApiResponse } from '@app/_models/api-response';
import { Job } from './../_models/job';
import { Observable } from 'rxjs';
import { CreateJobRequest } from './../_requests/create-job-request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UpdateJobRequest } from '@app/_requests/update-job-request';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private apiUrl = environment.baseUrl + 'api/jobs';

  constructor(private http:HttpClient) {
  }

  create(request:CreateJobRequest):Observable<Job>{
    return this.http.post<ApiResponse>(this.apiUrl, request )
      .pipe(
        map(result => { return <Job>result.data }),
      )
  }

  update(request:UpdateJobRequest):Observable<Job>{
    return this.http.put<ApiResponse>(this.apiUrl, request )
      .pipe(
        map(result => { return <Job>result.data }),
      )
  }

  get(id:string){
    return this.http.get<ApiResponse>(this.apiUrl+'/'+id+'/detail')
      .pipe(
        map(result => { return <Job>result.data }),
      )
  }

  getByUserId(userId:string){
    return this.http.get<ApiResponse>(this.apiUrl, { params: { userId: userId }} )
      .pipe(
        map(result => { return <Job[]>result.data }),
      )
  }

 
}
