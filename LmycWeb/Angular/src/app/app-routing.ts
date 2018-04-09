import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationComponent } from './reservation/reservation.component';
import { ReservationDetailComponent } from './reservation-detail/reservation-detail.component';
import { AddReservationComponent } from './add-reservation/add-reservation.component';


const routes: Routes = [
  { path: 'detail/:id', component: ReservationDetailComponent },
  { path: 'characters', component: ReservationComponent },
  { path: 'add', component: AddReservationComponent },

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
