import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MonthService {

  baseUrl= '/api/months';

  constructor(private http:HttpClient) { }

  getAllMonths(){
    return this.http.get(this.baseUrl+'/all');
  }

  getYears(){
    return this.http.get(this.baseUrl+'/years');
  }

  getMonths(year:string){
    return this.http.get(this.baseUrl+'?year='+year);
  }
}
