import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggingService {

  constructor() { }

  logEvent(eventDescription:string){}

  logError(errorDescription:string){}



}
