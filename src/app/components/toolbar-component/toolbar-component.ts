import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar'
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-toolbar-component',
  imports: [MatToolbarModule, MatIconModule, MatButtonModule, RouterLink],
  templateUrl: './toolbar-component.html',
  styleUrl: './toolbar-component.scss'
})
export class ToolbarComponent {

}
