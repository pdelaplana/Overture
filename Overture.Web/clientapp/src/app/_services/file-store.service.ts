import { ApiResponse } from '@app/_models/api-response';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileStoreService {
  private apiUrl: string = environment.baseUrl + 'api/file';

  constructor(private http: HttpClient) { }

  delete(fileReference: string):Observable<boolean>{
    return this.http.delete<ApiResponse>(`${this.apiUrl}/${fileReference}`)
      .pipe(
        map(result => { return <boolean>result.data }),
        
      )
  }

  get(fileReference:string):Observable<Blob>{
    return this.http.get(`${this.apiUrl}/${fileReference}`, {responseType: 'blob'});
  }
}
