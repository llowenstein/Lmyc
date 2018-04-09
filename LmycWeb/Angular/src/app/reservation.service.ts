import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { Reservation } from './reservation';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ReservationService {
  private apiUrl = 'https://localhost:44387/api/ReservationsAPI';
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  getItems(): Promise<Reservation[]> {
    return this.http.get(this.apiUrl)
      .toPromise()
      .then(response => response.json() as Reservation[])
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

  public getItemById(id: number): Promise<Reservation> {
    return this.getItems().then(result => result.find(res => res.reservationId === id));
  }

  add(newRes: Reservation): Promise<Reservation> {
    return this.http
      .post(this.apiUrl, JSON.stringify(newRes))
      .toPromise()
      .then(res => res.json().data)
      .catch(this.handleError);
  }

}
