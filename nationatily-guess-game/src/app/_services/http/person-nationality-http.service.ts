import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { PersonModel } from 'src/app/_models/person.model';


const API_URL = `${environment.apiUrl}`;

@Injectable({
  providedIn: 'root',
})
export class PersonNationalityHTTPService {
  constructor(private http: HttpClient) { }

  listPersonNationalities(): Observable<PersonModel[]> {


    const httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.get<PersonModel[]>(`${API_URL}PersonNationality`, {
      headers: httpHeaders,
    });

  }

}
