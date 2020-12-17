import { Router } from '@angular/router';
import { LoginService } from './login/login.service';
import { Component, OnInit } from '@angular/core';
import { LoginSuccessModel } from './Models/LoginSuccessModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  loggedInUser$ :  Observable<LoginSuccessModel>;

  constructor(private loginService: LoginService, private router:Router){

  }

  
  ngOnInit(): void {
    this.loggedInUser$=this.loginService.loginSuceess$;
    this.getCurrentUser();
  }

  getCurrentUser(){
    const token= localStorage.getItem('token');
    if(token){
      this.loginService.getCurrentUser(token).subscribe((res)=>{
        console.log(res);
      }, err=>console.log(err));

    }
  }

}
