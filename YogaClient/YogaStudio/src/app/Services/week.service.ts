import { YogaLessonToReturn } from './../Models/YogaLessonToReturn';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Week} from '../Models/Week';
import { YogaLessonDto } from '../Models/YogaLessonDto';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class WeekService {

   private selectedWeekSource= new BehaviorSubject<Week>(null);
   selectedWeek$=this.selectedWeekSource.asObservable();
   baseUrl= '/api/weeks';


  constructor(private http: HttpClient) { }

  getUpdatedSelectedWeek()  {
   return this.http.get(this.baseUrl+'/'+this.selectedWeekSource.value.id).
    pipe( map((res:Week)=>{
        this.selectedWeekSource.next(res);
        console.log("updatedWeek",res);
      }));
  }

  getWeekById(weekId){
    return this.http.get(this.baseUrl+'/'+weekId).
    pipe( map((res:Week)=>{
        this.selectedWeekSource.next(res);
        console.log("newWeek",res);
      }));
  
  }

  setSelectedWeek(week:Week){
    this.selectedWeekSource.next(week);
    this.orderClassesOfWeekByDays();
    console.log("selectedWeek", this.selectedWeekSource.value);
  }

  getSelectedWeek(){
    return this.selectedWeekSource.value;
  }

  getWeekByDate(date){
    this.http.get(this.baseUrl+'?startingDate='+date).
    pipe( map((res:Week)=>{
      this.selectedWeekSource.next(res);
      console.log("updatedWeek",res);
    }));
  }

  getWeeksOfMonth(monthId){
    return this.http.get(this.baseUrl+'/getbymonth/'+monthId);
  }
  
  orderClassesOfWeekByDays(){
    let classesByDays=[];
    for(let i=0; i<6; i++){
      classesByDays.push([]);
    }
    
    for(let yogaClass of this.selectedWeekSource.value.classesInWeek){
      classesByDays[yogaClass.day].push(yogaClass);
    }

    this.selectedWeekSource.value.classesInWeek=classesByDays;
  }

}
