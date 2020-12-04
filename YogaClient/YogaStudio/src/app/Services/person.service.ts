import { map } from 'rxjs/operators';
import { Person } from './../Models/Person';
import { ClassParticipated } from './../Models/ClassParticipated';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable, BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseUrl= "/api/person";
  private studentsSource = new BehaviorSubject<Person[]>(null);
  students$= this.studentsSource.asObservable();

  constructor(private http:HttpClient ) { }

  getAll(){
    return this.http.get(this.baseUrl+'/all').pipe(
      map((res:Person[])=>{
        this.studentsSource.next(res);
        console.log("students",res);
      }));
  }

  getPersons(month,year){
    return this.http.get(this.baseUrl+'?month='+month+'&year='+year);
  }

  getTotalDebtAndDebt(){
    return this.http.get(this.baseUrl+'/totalpaid&debt');
  }

  addClass(id:number,classParticipated:ClassParticipated) : 
  Observable<Person>{
    return this.http.post<Person>(this.baseUrl+'/addclass/'+id, classParticipated);
  }


}
