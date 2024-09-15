import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { region } from 'src/app/entities/region';
import { environment } from 'src/environments/environment';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class RegionService {

  list: region[] = [];

  constructor(
    private http: HttpClient
  ) { }

  GetAll(): Observable<region[]> {
    debugger
		  return this.http.get<region[]>('http://localhost:5023/Region')  
    }

   
}
