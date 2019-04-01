import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StringFormattingService {

  constructor() { }

  replace(value: string, strToReplace: string, replacementStr: string): string {
    if(!value || !strToReplace || !replacementStr)
    {
      return value;
    }
    return value.replace(new RegExp(strToReplace, 'g'), replacementStr);
  }

  titleCase(value:string):string{
    return value.toLowerCase().split(' ').map(function(word) {
      return (word.charAt(0).toUpperCase() + word.slice(1));
    }).join(' ');
  }


}
