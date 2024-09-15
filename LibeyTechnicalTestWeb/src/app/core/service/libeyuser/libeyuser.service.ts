import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
import { DocumentUser } from "src/app/entities/documentUser";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) {}

	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	getFindById( id: string ): Observable<LibeyUser|undefined> {
		return this.http.get<LibeyUser>(`${environment.pathLibeyTechnicalTest}LibeyUser/${id}`)
	  }

	addUser( user: LibeyUser ): Observable<LibeyUser> {
		return this.http.post<LibeyUser>(`${environment.pathLibeyTechnicalTest}LibeyUser`, user );
	  }

    GetAll(): Observable<LibeyUser[]> {
		return this.http.get<LibeyUser[]>(`${environment.pathLibeyTechnicalTest}LibeyUser`)
	  }

	  updateUser( user: LibeyUser ): Observable<LibeyUser> {
		return this.http.put<LibeyUser>(`${environment.pathLibeyTechnicalTest}LibeyUser`, user );
	  }
	
	  deleteUser( id : string ): Observable<boolean> {
		return this.http.delete<boolean>(`${environment.pathLibeyTechnicalTest}LibeyUser/${id}`);
	  }
	  
	  GetDocument(): Observable<DocumentUser[]> {
		return this.http.get<DocumentUser[]>(`${environment.pathLibeyTechnicalTest}LibeyUser/documentType`);
	  }
}
