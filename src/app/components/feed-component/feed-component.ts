import { Component, inject } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';
import { Report } from '../../model/report';
import { ReportCardComponent } from '../report-card-component/report-card-component';

@Component({
  selector: 'app-feed-component',
  imports: [ReportCardComponent],
  templateUrl: './feed-component.html',
  styleUrl: './feed-component.scss'
})
export class FeedComponent {

  private dataServ = inject(DataService);
  public reports: Report[] = [];

  constructor() {
    this.dataServ.getReports()
    .then((data) => {console.log(data); return data})
    .then((data) => this.reports = data);
  }



}
