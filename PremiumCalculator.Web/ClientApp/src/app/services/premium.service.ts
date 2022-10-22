import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer, Premium } from '../models';

@Injectable({
  providedIn: 'root'
})
export class PremiumService {

  constructor(private http: HttpClient) { }

  calculatePremium(customerDetails: Customer): Observable<Premium> {
    return this.http.post<Premium>('/premium', customerDetails);
  }
}
