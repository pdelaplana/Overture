import {  ApiResponse } from '../_models/api-response';
import { BusinessServiceCategory } from '@app/_models/business-service-category';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError,  map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class BusinessServiceCategoryService {
  private url = environment.baseUrl + 'api/categories';

    /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private log(message: string){ 
    console.log(message)
  }

  constructor(
    private http: HttpClient
  ) { }



  get():Observable<BusinessServiceCategory[]>{
    return this.http.get<ApiResponse>(this.url)
      .pipe(
        map(result => { return <BusinessServiceCategory[]>result.data }),
      )
  }


  getTopTen():Observable<BusinessServiceCategory[]>{
    return this.http.get<ApiResponse>(this.url+'?Top10=true')
      .pipe(
        map(result => { return <BusinessServiceCategory[]>result.data }),
      )
  }

}


