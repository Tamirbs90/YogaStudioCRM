import { ClassesService } from './../Services/classes.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Person } from '../Models/Person';

@Component({
  selector: 'app-debts',
  templateUrl: './debts.component.html',
  styleUrls: ['./debts.component.css']
})
export class DebtsComponent implements OnInit {

  showClassesId:number;
  persons:Person[];


  constructor(private classesService: ClassesService) { }

  ngOnInit(): void {
    this.GetDebtsList();
  }

  GetDebtsList(){
    this.classesService.getDebtsList().subscribe((res:Person[])=>this.persons=res);
  }
  
  setShowClassesId(id:number){
    if(this.showClassesId==id){
      this.showClassesId=0;
    }else{
      this.showClassesId=id;
    }
  }
}
