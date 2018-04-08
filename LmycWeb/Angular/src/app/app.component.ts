import { Component } from '@angular/core';
import { ReservationService } from './reservation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  reservations: string[];

  constructor(private resService: ReservationService) {
    this.reservations = [];
  }
}
