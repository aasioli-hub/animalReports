import { Injectable } from '@angular/core';
import { Feature } from '../../model/feature';
import { FeatureCollection } from '../../model/feature-collection';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(){
  }
  
  getReportsGeoJson(): Promise<FeatureCollection>{
    return fetch('./assets/reports.geojson')
    .then(resp => resp.json())
    .catch(err => console.error(err))
  }

}
