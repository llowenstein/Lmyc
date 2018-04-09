import { Component } from '@angular/core';
import { ReservationService } from './reservation.service';
import { Reservation } from './reservation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ReservationService]
})
export class AppComponent {
  title = 'Reservations';
  reservations: Reservation[];

  constructor(private resService: ReservationService) {
    this.resService.getItems().then(results => this.reservations = results);
  }
}
