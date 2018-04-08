import { Component, OnInit, Input } from '@angular/core';
import { ReservationService } from '../reservation.service';
import { ActivatedRoute, Params } from '@angular/router';
import { Reservation } from '../reservation';


@Component({
  selector: 'app-reservation-detail',
  templateUrl: './reservation-detail.component.html',
  styleUrls: ['./reservation-detail.component.css']
})
export class ReservationDetailComponent implements OnInit {

  constructor(private resService: ReservationService,
    private route: ActivatedRoute) { }

  @Input() 
    reservation: Reservation;

  ngOnInit() {
    this.route.params.forEach((params: Params) => {
      let id = +params['id'];
      this.resService.getItemById(id).then(result => this.reservation = result});
  }

}
