import { PersonService } from './../Services/person.service';
import { MonthService } from './../Services/month.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-datesearch',
  templateUrl: './datesearch.component.html',
  styleUrls: ['./datesearch.component.css']
})
export class DatesearchComponent implements OnInit {
  months: string[];
  years: string[];
  selectedMonth:string;
  selectedYear:string;
  @Input() totalPaid;
  @Input() totalDebt;
  @Output() monthChanged= new EventEmitter<string>();
  @Output() yearChanged= new EventEmitter<string>();



  constructor(private monthService: MonthService) {
   }

  ngOnInit(): void {
    //this.getCurrentMonthAndYear();
    this.getYears();
  }

  getYears(){
    this.monthService.getYears().subscribe((res:string[])=>{
      this.years=res;

    })
  }

  getCurrentMonthAndYear(){
    var date= new Date();
    this.selectedYear= date.getFullYear().toString();
    this.selectedMonth= date.toLocaleString(undefined,{month: 'long'}).toString();
    console.log('defaultYear',this.selectedYear);
    console.log('defaultMonth',this.selectedMonth);
  }


  getMonths(){
    this.monthService.getMonths(this.selectedYear).subscribe((res:string[])=>this.months=res);
  }

  onYearSelected(){
    this.getMonths();
  }

  changeMonthAndYear(){
    this.monthChanged.emit(this.selectedMonth);
    this.yearChanged.emit(this.selectedYear);
  }

  

}
