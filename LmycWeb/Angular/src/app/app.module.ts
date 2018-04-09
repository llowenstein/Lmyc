import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReservationService } from './reservation.service'  
import { RouterModule, Routes } from '@angular/router'; 
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { ReservationComponent } from './reservation/reservation.component';
import { ReservationDetailComponent } from './reservation-detail/reservation-detail.component';
import { AppRoutingModule } from './app-routing';
import { AddReservationComponent } from './add-reservation/add-reservation.component'; 

@NgModule({
  declarations: [
    AppComponent,
    ReservationComponent,
    ReservationDetailComponent,
    AddReservationComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
