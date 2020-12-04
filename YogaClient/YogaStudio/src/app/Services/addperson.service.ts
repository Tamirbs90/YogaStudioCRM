import { Observable } from 'rxjs';
import { Person } from './../Models/Person';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AddpersonService {

  private _personToUpdate: Person;

  baseUrl='/api/person/';

  constructor(private http: HttpClient) { }

  addPerson(person:Person): Observable<Person>{
    return this.http.post<Person>(this.baseUrl+'addperson',person);
  }

  updatePerson(): Observable<Person>{
    return this.http.put<Person>(this.baseUrl,this.personToUpdate);
  }

  public get personToUpdate(): Person {
    return this._personToUpdate;
  }
  
  public set personToUpdate(value: Person) {
    this._personToUpdate = value;
  }
}
