import { Business } from '@app/_models/business';
import { BusinessProfileService } from '@app/_services/business-profile.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { StringFormattingService } from '@app/_services/string-formatting.service';

@Component({
  selector: 'app-business-profile',
  templateUrl: './business-profile.component.html',
  styleUrls: ['./business-profile.component.css']
})
export class BusinessProfileComponent implements OnInit {

  business: Business = new Business();

  constructor(
    private route:ActivatedRoute,
    private businessProfileService: BusinessProfileService
  ) { }

  ngOnInit() {
    let altReference = this.route.snapshot.params.altReference;
    if (altReference){
      this.businessProfileService.getByAltReference(altReference).subscribe(profile=> {
        this.business = profile;
      })      
    }

    
  }

}
