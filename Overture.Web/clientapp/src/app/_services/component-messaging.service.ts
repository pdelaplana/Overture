import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ComponentMessagingService {
  private source = new BehaviorSubject<any>({});
  currentMessage = this.source.asObservable();

  constructor() { }

  sendMessage(message: any){
    this.source.next(message);
  }



}
