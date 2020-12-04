import { AddpersonService } from './../Services/addperson.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Person } from './../Models/Person';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-addstudent',
  templateUrl: './addstudent.component.html',
  styleUrls: ['./addstudent.component.css']
})
export class AddstudentComponent implements OnInit {

  personToAdd: Person;
  birthdayDays: number[]=[];
  months: number[]=[];
  addForm: FormGroup = new FormGroup({
    name: new FormControl('',Validators.required),
    phone: new FormControl('',Validators.required),
    bdayDay: new FormControl(''),
    bdayMonth: new FormControl(''),
    level: new FormControl(''),
    isActive: new FormControl(false)
  });

  constructor(private addPersonService: AddpersonService) { 

  }

  ngOnInit(): void {
    if(this.birthdayDays.length==0){
      for(let i=1; i<32; i++){
        this.birthdayDays.push(i);
      }
    }

    if(this.months.length==0){
      for(let j=1; j<13; j++){
        this.months.push(j);
      }
    }

    if(this.addPersonService.personToUpdate !=null)
    {
      this.addForm.patchValue({
        name: this.addPersonService.personToUpdate.name,
        phone: this.addPersonService.personToUpdate.phone,
        bdayDay: this.addPersonService.personToUpdate.birthday.substr(0,this.addPersonService.personToUpdate.birthday.indexOf('/')),
        bdayMonth: this.addPersonService.personToUpdate.birthday.substr(this.addPersonService.personToUpdate.birthday.indexOf('/')+1),
        level: this.addPersonService.personToUpdate.level,
        isActive: this.addPersonService.personToUpdate.isActive
      });
    }
  }

  addPerson(){
    this.addPersonService.addPerson(this.personToAdd).subscribe((res:Person)=>
    {
      console.log(res);
    });
  }

  updatePerson(){
    this.addPersonService.updatePerson().subscribe((res:Person)=>
    {console.log(res);
     this.addPersonService.personToUpdate=null;
    } 
     );
  }

  addOrUpdate(){
    if(this.addPersonService.personToUpdate !=null)
    {
      this.setPerson(this.addPersonService.personToUpdate);
      console.log(this.addPersonService.personToUpdate);
      console.log("updating person");
      this.updatePerson();
    }
    else{
      console.log("adding new person");
      this.personToAdd= new Person();
      this.setPerson(this.personToAdd);
      this.personToAdd.studentClasses=[];
      console.log(this.personToAdd);
      this.addPerson();
    }

    this.addForm.reset();
 }

 setPerson(person:Person){
  person.name=this.PersonName.value;
  person.phone=this.PersonPhone.value;
  person.birthday=this.PersonBdayDay.value+'/'+this.PersonBdayMonth.value;
  person.level=Number(this.PersonLevel.value);
  person.isActive=this.PersonIsActive.value;
 }

  get PersonName() {return this.addForm.get("name");}
  get PersonPhone(){return this.addForm.get("phone");}
  get PersonBdayDay(){return this.addForm.get("bdayDay");}
  get PersonBdayMonth(){return this.addForm.get("bdayMonth");}
  get PersonLevel(){return this.addForm.get("level");}
  get PersonIsActive() {return this.addForm.get("isActive");}


}
