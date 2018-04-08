import { Component, OnInit } from '@angular/core';
import { ReservationService } from '../reservation.service';
import { Router } from '@angular/router';
import { Reservation } from '../reservation';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  reservations: Reservation[];

  constructor(private resService: ReservationService, private router: Router) {}

  ngOnInit() {
  }

  getReservations(): void {
    this.resService.getItems();
  }

}
