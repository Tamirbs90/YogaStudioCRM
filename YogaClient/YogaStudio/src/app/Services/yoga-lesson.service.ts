import { map } from 'rxjs/operators';
import { YogaLessonToReturn } from './../Models/YogaLessonToReturn';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { YogaLessonDto } from '../Models/YogaLessonDto';

@Injectable({
  providedIn: 'root'
})
export class YogaLessonService {


  selectedClassSource= new BehaviorSubject<YogaLessonToReturn>(null);
  selectedClass$=this.selectedClassSource.asObservable();
  baseUrl='/api/YogaLesson/';

  constructor(private http: HttpClient) { }

  getClassById(id) {
    return this.http.get(this.baseUrl+id).
    pipe(map((res:YogaLessonToReturn)=>this.selectedClassSource.next(res)));
  }

  getSelectedClass(){
    return this.selectedClassSource.value;

  }

  addOrUpdateClass(weekId,monthId, lesson: YogaLessonDto){
    return this.http.post(this.baseUrl+weekId+'/'+monthId,lesson).
    pipe( map((res:YogaLessonToReturn)=>{
      console.log("updatedLessonFromServer", res);
      this.selectedClassSource.next(res);

    }));
  }

  

  addStudentToClass(yogaLesson:YogaLessonDto, studentId){
    if(!this.isStudentInClass(yogaLesson,studentId)){
      return this.http.get(this.baseUrl+'add/'+yogaLesson.id+'/'+studentId);
      }
    }

  updateYogaClass(yogaClass: YogaLessonDto){
    this.http.put(this.baseUrl+'update',yogaClass).subscribe((res:YogaLessonDto)=>console.log(res));
  }

  deleteStudentFromClass(classId, StudentId){
    return this.http.delete(this.baseUrl+'fromclass/'+classId+'/'+StudentId);

  }

  deleteClass(classId){
    return this.http.delete(this.baseUrl+classId);
  }

  resetSelectedClass(){
    this.selectedClassSource.next(null);
  }

  getParticipationsIds(yogaLesson:YogaLessonToReturn){
    let res=[];
    for(let participation of yogaLesson.studentsParticipated){
      res.push(participation.person.id);
    }
    return res;
  }

  filterExistingStudents(studentIds:string[]){
    for(let i=0; i<studentIds.length; i++)
    {
      if(this.getSelectedClass().studentsParticipated.
      findIndex(p=>p.person.id===Number(studentIds[i]))!==-1)
      {
        studentIds.splice(i,1);
      }
    }
  }



  isStudentInClass(yogaLesson: YogaLessonDto, studentId){
    for(let id of yogaLesson.studentsIds){
      if(id===studentId){
        return true;
      }
    }
    return false;
  }
}
