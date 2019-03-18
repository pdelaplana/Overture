import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Registration } from '@app/_models/registration';
import { User } from '@app/_models/user';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ApiResponse } from './../_models/api-response';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private url = environment.baseUrl + 'api/registration';

  constructor(
    private http : HttpClient
  ) { }

  register(registration:Registration):Observable<User>{
    return this.http.post<ApiResponse>(this.url, registration, httpOptions )
      .pipe(
        map(result => { return <User>result.data }),

      )

  }
}
