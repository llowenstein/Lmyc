import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReservationService } from './reservation.service'  
import { RouterModule } from '@angular/router'; 
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { ReservationComponent } from './reservation/reservation.component';
import { ReservationDetailComponent } from './reservation-detail/reservation-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ReservationComponent,
    ReservationDetailComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule
  ],
  providers: [ReservationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
