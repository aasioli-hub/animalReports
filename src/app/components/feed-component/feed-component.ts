import { Component, inject } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';
import { Report } from '../../model/report';
import { ReportCardComponent } from '../report-card-component/report-card-component';
import { LocationService } from '../../services/location-service/location-service';

@Component({
  selector: 'app-feed-component',
  imports: [ReportCardComponent],
  templateUrl: './feed-component.html',
  styleUrl: './feed-component.scss',
})
export class FeedComponent {
  private dataServ = inject(DataService);
  private locationServ = inject(LocationService);
  public reports: Report[] = [];

  constructor() {
    // this.dataServ.getReports().then((data) => {
    //   if ('geolocation' in navigator) {
    //     this.locationServ.sortReportsByDistance(data)
    //     .then((sortedReports) => this.reports = sortedReports)
    //   } else {
    //     this.reports = data;
    //   }
    // });

    // this.dataServ.getReports().then((data) => {
    //   if ('geolocation' in navigator) {
    //     return this.locationServ.sortReportsByDistance(data)
    //   } else {
    //     return data;
    //   }
    // }).then(newReports => this.reports = newReports);
    this.loadReports()
  }

  async loadReports(){
    const unorderedReports = await this.dataServ.getReports()
    if ('geolocation' in navigator) {
        const orderdReports = await this.locationServ.sortReportsByDistance(unorderedReports);
        this.reports = orderdReports;
    } else {
        this.reports = unorderedReports;
    }

  }
}
