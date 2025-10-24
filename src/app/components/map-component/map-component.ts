import { Component, inject } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';
import * as L from 'leaflet';
import { Feature } from '../../model/feature';
import { GeoJsonObject } from 'geojson';
import { C } from '@angular/cdk/keycodes';

@Component({
  selector: 'app-map-component',
  imports: [],
  templateUrl: './map-component.html',
  styleUrl: './map-component.scss',
})
export class MapComponent {
  private map: L.Map | undefined;

  // private dataServ = inject(DataService);
  constructor(private dataServ: DataService) {}

  ngAfterViewInit() {
    this.setupMap();

    // this.testClojure();
  }

  async setupMap() {
    this.map = L.map('map');

    this.map.setView([44.40614435613236, 8.949400422559357], 13);

    const tileLayer = L.tileLayer(
      'https://tile.openstreetmap.org/{z}/{x}/{y}.png',
      {
        maxZoom: 19,
        attribution:
          '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
      }
    );

    tileLayer.addTo(this.map);

    const reports = await this.dataServ.getReportsGeoJson();

    const geojsonLayer = L.geoJSON(reports as GeoJsonObject, {
      pointToLayer: this.myPointToLayer,
      onEachFeature: this.myOnEachFeature,
    });

    geojsonLayer.addTo(this.map);
  }

  myPointToLayer(point: any, latLng: L.LatLng) {
    const geojsonMarkerOptions = {
      radius: 8,
      fillColor: '#ff7800',
      color: '#000',
      weight: 1,
      opacity: 1,
      fillOpacity: 0.8,
    };
    return L.circleMarker(latLng, geojsonMarkerOptions);
  }

  myOnEachFeature(point: any, layer: L.Layer) {

    // const createPopupContent = (props: any) => {
    //   let result = '';
    //   for (const key in props) {
    //     const value = props[key];
    //     result += `<span><strong>${key}:</strong> ${value}</span><br/>`;
    //   }
    //   return result;
    // };

    if (point.properties && point.properties.title) {
      console.log('point properties:', point.properties);
      const content = createPopupContent(point.properties);
      layer.bindPopup(content);
    }
  }

  // createPopupContent(point: any): string {
  //   let result = '';

  //   for (const key in point) {
  //     const value = point[key];
  //     result += `<span><strong>${key}:</strong> ${value}</span><br/>`;
  //   }

  //   return result;
  // }

  // testClojure() {
  //   let functionVariable;
  //   {
  //     let counter = 0;
  //     functionVariable = () => {
  //       counter = counter + 1;
  //       console.log('Counter value:', counter);
  //     };
  //   }
  //   functionVariable();
  //   functionVariable();
  //   functionVariable();

  // }
}


function createPopupContent(properties: any): string {
  let result = '';  
  for (const key in properties) {
    const value = properties[key];
    result += `<span><strong>${key}:</strong> ${value}</span><br/>`;
  }
  return result;
}