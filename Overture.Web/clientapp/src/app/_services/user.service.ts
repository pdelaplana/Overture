import { UpdateUserRequest } from './../_requests/update-user-request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '@app/_models/user';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { ApiResponse } from '@app/_models/api-response';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = environment.baseUrl + 'api/users';

  constructor(
    private http: HttpClient
  ) { }

  getUserByEmail(email:string):Observable<User>{
    return this.http.get<ApiResponse>(this.apiUrl, { params: { email: email }} )
      .pipe(
        map(result => { return <User>result.data }),
        
      )
  }

  update(request:UpdateUserRequest):Observable<User>{
    return this.http.put<ApiResponse>(this.apiUrl, request )
      .pipe(
        map(result => { return <User>result.data }),
        
      )
  }
}
