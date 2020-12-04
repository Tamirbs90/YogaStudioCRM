import { AddpersonService } from './../Services/addperson.service';
import { ClassesService } from './../Services/classes.service';
import { ClassParticipated } from './../Models/ClassParticipated';
import { PersonService } from './../Services/person.service';
import { Component, OnInit, ɵsetCurrentInjector } from '@angular/core';
import {Person} from '../Models/Person';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-listpage',
  templateUrl: './listpage.component.html',
  styleUrls: ['./listpage.component.css']
})
export class ListpageComponent implements OnInit {

  persons: Person[];
  debtsList: Person[];
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
    console.log("persons",this.persons);
  }

  getPersons(){
      this.personService.getPersons(this.selectedMonth,this.selectedYear).
      subscribe((res:any)=>{
        this.persons=res.studentsList;
        this.totalPaid=res.totalPaid;
        this.totalDebt=res.totalDebt;
        console.log(this.persons);
        console.log(this.totalPaid);
        console.log(this.totalDebt);
      });
  }


    addClassToStudent(id:number){
      this.classToAdd= new ClassParticipated(this.ClassDate.value,Number(this.ClassPaid.value),Number(this.ClassDebt.value));
      console.log(this.classToAdd);
      this.classesService.addClass(id,this.classToAdd).subscribe((res:Person)=>{
        console.log(res);
        this.classForm.reset('');
    
        this.getPersons();
      });
    }

    setParticipationToUpdate(partcipation){
      this.participationToUpdate= partcipation;
    }

    updateParticipation( id ,date, paid, debt, personId){
      let updatedParticipation= new ClassParticipated(date,Number(paid),Number(debt));
      updatedParticipation.id= Number(id);
      updatedParticipation.personId=personId;
      console.log("updatedParticipation", updatedParticipation);
      this.classesService.updateParticipation(updatedParticipation).subscribe(()=>
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


    onMonthChanged(month:any){
      this.selectedMonth=month;
      console.log(this.selectedMonth);
    }

    onYearChanged(year:any){
      this.selectedYear=year;
      console.log(this.selectedYear);
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
