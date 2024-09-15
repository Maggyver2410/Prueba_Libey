import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { province } from 'src/app/entities/province';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {

  list: province[] = [];

  constructor(
    private http: HttpClient
  ) { }

  GetProvince(code: string): Observable<province[]> {
    return this.http.get<province[]>(`${environment.pathLibeyTechnicalTest}province/${code}`)      
  }
   
}
