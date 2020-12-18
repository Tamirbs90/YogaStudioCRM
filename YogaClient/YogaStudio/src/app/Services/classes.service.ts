import { ClassParticipated } from './../Models/ClassParticipated';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../Models/Person';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {

  baseUrl= '/api/classes/';

  constructor(private http: HttpClient) { }

  addClass(studentId:number,monthId:number,classParticipated:ClassParticipated) : 
  Observable<Person>{
    return this.http.post<Person>(this.baseUrl+'addclass/'+studentId+'/'+monthId, classParticipated);
  }

  deleteClass(classId: number) : Observable<Person>{
    return this.http.delete<Person>(this.baseUrl+classId);

  }

  updateParticipation(participation: ClassParticipated){
    return this.http.put(this.baseUrl+'update', participation);
  }

  getDebtsList(): Observable<Person[]>{
    return this.http.get<Person[]>(this.baseUrl+'debts');
  }

}
