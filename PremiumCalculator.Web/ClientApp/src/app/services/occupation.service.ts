import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Occupation } from '../models';

@Injectable({
  providedIn: 'root'
})
export class OccupationService {

  constructor(private http: HttpClient) { }

  getOccupations(): Observable<Occupation[]> {
    return this.http.get<Occupation[]>('/occupation');
  }
}
