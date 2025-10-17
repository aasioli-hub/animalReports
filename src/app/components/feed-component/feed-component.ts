import { Component, inject } from '@angular/core';
import { DataService } from '../../services/data-service/data-service';

@Component({
  selector: 'app-feed-component',
  imports: [],
  templateUrl: './feed-component.html',
  styleUrl: './feed-component.scss'
})
export class FeedComponent {

  private dataServ = inject(DataService);


}
