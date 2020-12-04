import { MonthService } from './../../Services/month.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Week } from 'src/app/Models/Week';
import {Month} from 'src/app/Models/Month';
import { WeekService } from 'src/app/Services/week.service';

@Component({
  selector: 'app-searchtab',
  templateUrl: './searchtab.component.html',
  styleUrls: ['./searchtab.component.css']
})
export class SearchtabComponent implements OnInit {

 @Output() weekEmitter = new EventEmitter<number>()
 @Output() monthEmitter = new EventEmitter<number>();
 months: any[]=[];
 weeks: any[]=[];
 selectedMonthId:number;
 selectedWeekId:number;


  constructor(private weekService: WeekService, private monthService: MonthService) { }

  ngOnInit(): void {
    this.getMonthsList();
  }

  getMonthsList(){
    this.monthService.getAllMonths().subscribe((res:any[])=>
    {this.months=res;
      console.log(res);
    });
  }

  onWeekChange(event:any){
    this.selectedWeekId=event.target.value;
    console.log("week changed",this.selectedWeekId)
  }


  onMonthSelected(){
    console.log('selectedMonth',this.selectedMonthId);
    this.weekService.getWeeksOfMonth(this.selectedMonthId).subscribe((res:any[])=>{
      console.log("weeks of selected Month", res);
      this.weeks=res;
    });

  }


  onWeekSelected(){
    this.monthEmitter.emit(this.selectedMonthId);
    this.weekEmitter.emit(this.selectedWeekId);

  }

  isSeletedMonthDefined(){
    return typeof(this.selectedMonthId)!=='undefined';
  }

}
