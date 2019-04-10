import { inject } from '@angular/core/testing';
import { Router } from '@angular/router';
import auth0 from 'auth0-js';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, config, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '@app/_models/user';
import { ApiResponse } from '@app/_models/api-response';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl = environment.baseUrl + 'api/authenticate';
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  
  /*
  private auth0 = new auth0.WebAuth({
    clientID: environment.auth0.clientId,
    domain: environment.auth0.domain,
    responseType: 'token',
    redirectUri: environment.auth0.redirectUri,
    scope: 'openid'
  });
  */

 private handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
    // A client-side or network error occurred. Handle it accordingly.
    console.error('An error occurred:', error.error.message);
  } else {
    // The backend returned an unsuccessful response code.
    // The response body may contain clues as to what went wrong,
    console.error(
      `Backend returned code ${error.status}, ` +
      `body was: ${error.error}`);
  }
  // return an observable with a user-facing error message
  return throwError(
    'Something bad happened; please try again later.');
};

  constructor(
    private http:HttpClient, 
    //private router: Router
  ) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  public get isUserAuthenticated():boolean{
    return this.currentUserSubject.value != null
  }

  /*
  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        const expiresAt = (authResult.expiresIn * 1000) + new Date().getTime();
        let currentUser = new User();
        currentUser.accessToken = authResult.accessToken;
        currentUser.idToken = authResult.idToken;
        currentUser.expiresAt = expiresAt;

        
        this.auth0.client.userInfo(authResult.accessToken, function(err, user){
          currentUser.userId = user.sub;
          currentUser.name = user.nickname;
          currentUser.email = user.name;
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(currentUser));
          this.currentUserSubject.next(currentUser);

        })
        this.router.navigate(['/']);
      } else if (err) {
        this.router.navigate(['/home']);
        console.log(err);
      }
    });
  }

  public login(){
    this.auth0.authorize();
  } 
  */

  public loginWithCredentials(username: string, password: string):Observable<User> {
    /*
    this.auth0.login({
      realm: 'Username-Password-Authentication',
      email: username,
      password: password,
    }, function(err) {
      if (err) console.log(err);
    });
    */
    
    //return this.http.post<User>(`${this.apiUrl}`, { username, password })
    return this.http.post<ApiResponse>(this.apiUrl, { email: username, password: password }, httpOptions)
        .pipe(
          map(result => {
            // login successful if there's a jwt token in the response
            let user = <User>result.data
            if (user && user.accessToken) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
            }

            return user;
          }),
          catchError(this.handleError)
        );
    
  }

  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('currentUser');
      this.currentUserSubject.next(null);
  }

}
