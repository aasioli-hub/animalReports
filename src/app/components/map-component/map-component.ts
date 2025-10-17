import { Component, inject } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';
import * as L from 'leaflet';
import { Feature } from '../../model/feature';

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

    const geojsonLayer = L.geoJSON(reports as any, {
      pointToLayer: this.myPointToLayer,
      onEachFeature: this.myOnEachFeature
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
    if (point.properties && point.properties.title) {
      layer.bindPopup(point.properties.title);
    }
  }
}
