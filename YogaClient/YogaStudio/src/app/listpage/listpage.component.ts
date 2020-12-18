import { AddpersonService } from './../Services/addperson.service';
import { ClassesService } from './../Services/classes.service';
import { ClassParticipated } from './../Models/ClassParticipated';
import { PersonService } from './../Services/person.service';
import { Component, OnInit, ɵsetCurrentInjector } from '@angular/core';
import {Person} from '../Models/Person';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-listpage',
  templateUrl: './listpage.component.html',
  styleUrls: ['./listpage.component.css']
})
export class ListpageComponent implements OnInit {

  persons: Person[];
  debtsList: Person[];
  selectedMonthId:number;
  selectedMonth: string;
  selectedYear: string;
  classToAdd: ClassParticipated;
  participationToUpdate: ClassParticipated;
  showClassesId:number;
  addClassId:number;
  totalPaid:number;
  totalDebt:number;
  classForm: FormGroup = new FormGroup({
    date: new FormControl('', Validators.required),
    paid: new FormControl('', Validators.required),
    debt: new FormControl('', Validators.required)
  });


  constructor(private personService: PersonService, private classesService: ClassesService, 
    private addPersonService: AddpersonService ) { }

  ngOnInit(): void {
  }


  getPersons(){
      this.personService.getPersons(this.selectedMonth,this.selectedYear).
      subscribe((res:any)=>{
        this.updateProperties(res);
      });
  }

  getCurrentMonthDetails(){
    this.personService.getCurrentMonthDetails().subscribe((res:any)=>{
      if(res){
        console.log('list',res);
        this.updateProperties(res);
      }
    })
  }


    addClassToStudent(studentId:number){
      this.classToAdd= new ClassParticipated(this.ClassDate.value,Number(this.ClassPaid.value),Number(this.ClassDebt.value));
      this.classesService.addClass(studentId,this.selectedMonthId,this.classToAdd).
      subscribe((res:Person)=>{
        this.classForm.reset('');
         this.getPersons();
      });
    }

    setParticipationToUpdate(partcipation){
      this.participationToUpdate= partcipation;
    }

    updateParticipation(classParticipated:ClassParticipated, debt, paid){
      this.participationToUpdate= classParticipated;
      this.participationToUpdate.debt= Number(debt);
      this.participationToUpdate.paid=Number(paid);

      console.log("updatedParticipation", this.participationToUpdate);
      this.classesService.updateParticipation(this.participationToUpdate).subscribe(()=>
      {
        this.getPersons();
      });
    }

    deleteClassFromStudent(classId: number){
      if(confirm("Are you sure you want to delete details?")){
        this.classesService.deleteClass(classId).subscribe((res:Person)=>{
          console.log(res);
          this.getPersons();
        });
      }
    }

    edit(personToEdit:Person){
    console.log(personToEdit);
      this.addPersonService.personToUpdate=personToEdit;
      console.log(this.addPersonService.personToUpdate);

    }

    updateProperties(res){
      this.persons=res.studentsList;
      this.totalPaid=res.totalPaid;
      this.totalDebt=res.totalDebt;
      this.selectedMonthId=res.selectedMonthId;
    }


    onMonthChanged(month:any){
      this.selectedMonth=month;
    }

    onYearChanged(year:any){
      this.selectedYear=year;
      this.getPersons();
    }

    setShowClassesId(id:number){
      if(this.showClassesId==id){
        this.showClassesId=0;
      }else{
        this.showClassesId=id;
      }
    }

    setAddClassId(id:number){
      if(this.addClassId==id){
        this.addClassId=0;
      }else{
        this.addClassId=id;
      }
      
      this.classForm.reset();
    }



    get ClassDate(){return this.classForm.get("date");}
    get ClassPaid(){return this.classForm.get("paid");}
    get ClassDebt(){return this.classForm.get("debt");}




}
