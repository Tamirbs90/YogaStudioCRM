import { browser } from 'protractor';
import { YogaLessonToReturn } from './../../Models/YogaLessonToReturn';
import { async } from '@angular/core/testing';
import { ClassesService } from './../../Services/classes.service';
import { YogaLessonDto } from './../../Models/YogaLessonDto';
import { Observable } from 'rxjs';
import { Month } from 'src/app/Models/Month';
import { SearchtabComponent } from './../searchtab/searchtab.component';
import { StudentInClass } from './../../Models/StudentInClass';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PersonService } from './../../Services/person.service';
import { YogaLessonService } from './../../Services/yoga-lesson.service';
import { WeekService } from 'src/app/Services/week.service';
import { Week } from './../../Models/Week';
import { Component, OnInit, ViewChild, ɵsetCurrentInjector } from '@angular/core';
import { Person } from 'src/app/Models/Person';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  selectedWeek$:Observable<Week>;
  studentsList$:Observable<Person[]>;
  selectedClass$: Observable<YogaLessonToReturn>;
  selectedMonthId:number;
  selectedWeelId:number;
  openClassEditWindow: boolean;
  updateClass:boolean;
  startingDate: Date;
  selectedDay: number;
  studentToAdd: Person;
  newClassForm: FormGroup= new FormGroup({
    day: new FormControl(""),
    startHour: new FormControl("", Validators.required),
    endHour : new FormControl("", Validators.required),
    studentsParticipated :new FormControl(null)
  });




  constructor(private weekService: WeekService, 
    private yogaLessonService:YogaLessonService, 
    private personService:PersonService
    ,private participationService: ClassesService) { }

  ngOnInit(): void {
    this.personService.getAll().subscribe();
    this.studentsList$=this.personService.students$;
    this.selectedWeek$=this.weekService.selectedWeek$;
    this.selectedClass$= this.yogaLessonService.selectedClass$;
  }

  onSelectedWeek(weekId: number){
    console.log("selectedWeek", weekId);
    this.weekService.getWeekById(weekId).subscribe(()=>{
      
    this.startingDate= new Date(this.weekService.getSelectedWeek().startingDate);
    console.log("starting date", this.startingDate);
    });

  }

  onSelectedMonth(month: number){
    this.selectedMonthId=month;
}
  
  addOrUpdateClassToWeek(weekId, selectedDay){
    this.newClassForm.patchValue({day:selectedDay});
    let startTime= this.formNewDate(true);
    let endTime= this.formNewDate(false);
    let newClass= new YogaLessonDto(selectedDay,startTime,endTime);
    newClass.studentsIds=this.newClassForm.get('studentsParticipated').value;
     if(this.updateClass){
       newClass.id=this.getSelectedClass().id;
     }
   
    console.log("newclass", newClass);
    this.yogaLessonService.addOrUpdateClass(weekId,this.selectedMonthId, newClass).
    subscribe(()=>{
      this.updateSelectedWeek();
      if(this.updateClass){
        this.getClassDetails(this.getSelectedClass().id);
      }
    });
  }

  getDate(daysToAdd){
    let date= new Date();
    date.setDate(this.startingDate.getDate()+daysToAdd);
    return date;
  }

  formNewDate(start:boolean){
    let startHour= this.newClassForm.get('startHour').value.substring(0,2);
    let startMinute= this.newClassForm.get('startHour').value.substring(3);
    let endHour= this.newClassForm.get('endHour').value.substring(0,2);
    let endMinute= this.newClassForm.get('endHour').value.substring(3);
    let newDate= new Date(this.weekService.getSelectedWeek().startingDate);
    start? newDate.setHours(startHour): newDate.setHours(endHour);
    start? newDate.setMinutes(startMinute) : newDate.setMinutes(endMinute);
    return newDate;
  }

 getClassDetails(classId){
   this.yogaLessonService.getClassById(classId).subscribe(()=>
   {
    this.openClassEditWindow=true;
    this.updateClass=true;
    const currSelectedClass= this.getSelectedClass();
    let startTime= new Date(currSelectedClass.startingTime);
    let endTime= new Date(currSelectedClass.endTime);
    let startHour= (startTime.getHours() <10 ? '0' : '')+startTime.getHours();
    let startMinute=(startTime.getMinutes() <10? '0' : '')+startTime.getMinutes();
    let endHour= (endTime.getHours()<10 ? '0' : '') + endTime.getHours();
    let endMinute= (endTime.getMinutes() <10? '0' : '')+endTime.getMinutes();
    console.log('startHour', startHour);
    this.selectedDay=currSelectedClass.day;
     this.newClassForm.setValue({
       day: currSelectedClass.day,
       startHour: startHour+':'+startMinute,
       endHour: endHour+':'+endMinute,
       studentsParticipated: this.yogaLessonService.getParticipationsIds(currSelectedClass)
     });
   })

  }

  deleteClass(classId){
    if(confirm("Are you sure you want to delete class?")){
      return this.yogaLessonService.deleteClass(classId).subscribe(()=>{
        this.updateSelectedWeek();
      })
    }
  }

  closeWindow(){
    this.newClassForm.reset();
    this.yogaLessonService.resetSelectedClass();
    this.openClassEditWindow=false;
    this.updateClass=false;
  }

  updateSelectedWeek(){
    this.weekService.getUpdatedSelectedWeek().subscribe();
  }

  getSelectedWeek(){
    return this.weekService.getSelectedWeek();
  }

  getSelectedClass(){
    return this.yogaLessonService.selectedClassSource.value;
  }

  getClassbyId(id){
    return this.yogaLessonService.getClassById(id);
  }


  addStudentToClass(yogaClass,studentId){
    return this.yogaLessonService.addStudentToClass(yogaClass,studentId).
    subscribe((res:YogaLessonDto)=>{
      this.updateSelectedWeek();
      this.getClassDetails(this.getSelectedClass().id);
    })
  }

  isUserExistsInClass(yogaClass, studentId){
    return this.yogaLessonService.isStudentInClass(yogaClass,studentId);
  }

  deleteStudentFromClass(participationId:number){
    if(confirm("Are you sure you want to delete student from class?")){
      this.participationService.deleteClass(participationId).subscribe((res:Person)=>
    {
      this.updateSelectedWeek();
      this.getClassDetails(this.getSelectedClass().id);
    });
    }
  }
}


