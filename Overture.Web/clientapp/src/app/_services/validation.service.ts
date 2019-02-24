import { FormControl } from '@angular/forms';
import { Injectable } from '@angular/core';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {
  debouncer:any;

  constructor(
    private userService: UserService
  ) { }

  checkEmailIsUnique(control:FormControl){
    clearTimeout(this.debouncer);
    return new Promise(resolve => {
      this.debouncer = setTimeout(()=>{
        this.userService.getUserByEmail(control.value)
          .subscribe(user => {
            if ((user != null)&&(user.email==control.value)) {
              resolve({emailInUse:(user.email == control.value)});
            } else {
              resolve(null)
            }
            
          },err =>{
            resolve(null)
          })
      },1000)
    })
  }

  checkEmailInUse(control:FormControl){
    this.userService.getUserByEmail(control.value)
      .subscribe(user => {
        return {emailInUse:(user != null)};
      },err =>{
        return null;
      })
  }
}
