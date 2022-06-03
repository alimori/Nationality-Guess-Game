
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { PersonModel } from '../_models/person.model';
import { PersonNationalityHTTPService } from './http/person-nationality-http.service';
import { map, catchError, finalize } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class PersonService {

    constructor(private personNationalityHttpService: PersonNationalityHTTPService) {
    }

    getPersons(): Observable<PersonModel[]> {
        return this.personNationalityHttpService.listPersonNationalities().pipe(
            map((result: any) => {
                return result;
            }),
            catchError((err) => {
                console.error('err', err);
                return of([]);
            }),
            finalize(() => { })
        );
    }


}