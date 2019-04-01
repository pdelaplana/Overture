import { FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { BusinessService } from '@app/_models/business-service';
import { ReferenceDataService } from '@app/_services/reference-data.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { ServiceArea } from '@app/_models/service-area';

@Component({
  selector: 'app-search-control-panel',
  templateUrl: './search-control-panel.component.html',
  styleUrls: ['./search-control-panel.component.css']
})
export class SearchControlPanelComponent implements OnInit {

  dataSources : {
    businessServices: BusinessService[],
    serviceAreas: ServiceArea[]
  } = { businessServices: [], serviceAreas: [] } 

  searchForm: FormGroup

  @Input() selectedCategories: string[] = [];
  @Input() selectedServices: any[] = [];
  
  @Output() onServicesCriteriaChange = new EventEmitter();
  @Output() onAreasCriteriaChange = new EventEmitter();


  constructor(
    private formBuilder: FormBuilder,
    private referenceDataService:ReferenceDataService
  ) { }

  ngOnInit() {
    this.referenceDataService.getBusinessServices().subscribe(services => { 
      this.dataSources.businessServices = services;
      for (let cat of this.selectedCategories){
        let service = this.dataSources.businessServices.find(s =>s.categoryName.toLowerCase() == cat.toLowerCase()  );
        if (service != null){
          this.selectedServices.push( { 'categoryName' : service.categoryName });
          this.searchForm.controls.services.setValue(this.selectedServices);
        }  
      }
  
    });
    this.referenceDataService.getServiceAreas().subscribe(areas => { this.dataSources.serviceAreas = areas });

    
    this.searchForm = this.formBuilder.group({
      services: [],
      areas: []
    });
   
  
    this.searchForm.controls.services.valueChanges.subscribe(val => {
      this.onServicesCriteriaChange.emit(val.map(s=>s.name || s.categoryName));
    });

    this.searchForm.controls.areas.valueChanges.subscribe(val => {
      this.onAreasCriteriaChange.emit(val.map(a=>a.name));
    })
  }

  

  selectedServicesFn = (item, selected) => {
    if (selected.categoryName && item.categoryName) {
        return item.categoryName === selected.categoryName;
    }
    if (item.categoryName && selected.categoryName) {
        return item.categoryName === selected.categoryName;
    }
    return false;
  };


}
