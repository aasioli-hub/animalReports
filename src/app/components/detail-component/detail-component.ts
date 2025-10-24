import { Component, inject } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';
import { Report } from '../../model/report';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail-component',
  imports: [],
  templateUrl: './detail-component.html',
  styleUrl: './detail-component.scss'
})
export class DetailComponent {
 private dataServ = inject(DataService);
 private route = inject(ActivatedRoute);
 public report: Report |null =  null;
 constructor()  {  
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.dataServ.getReport(id).then((data) => this.report = data);
 }
}
