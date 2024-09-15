import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ubigeo } from 'src/app/entities/ubigeo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UbigeoService {

  constructor(  
    private http: HttpClient) 
    { }

  GetUbigeo(code: string): Observable<ubigeo[]> {
    return this.http.get<ubigeo[]>(`${environment.pathLibeyTechnicalTest}ubigeo/${code}`)      
  }
   
}
