import { Output } from '@angular/core';
import { Component, OnInit, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDto } from 'src/app/Models/LoginDto';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loginInfo= new LoginDto();
  errorMessage:string='';

  constructor(private loginService : LoginService, private router:Router) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login(){
    this.loginService.login(this.loginInfo).
    subscribe((res)=>{
      this.router.navigateByUrl('/students');
      this.errorMessage='';
    }
    ,err=>this.errorMessage=err.error);
  }

  getCurrentUser(){
    const token= localStorage.getItem('token');
    if(token){
      this.loginService.getCurrentUser(token).subscribe((res)=>{
        this.router.navigateByUrl('/students');
      })
    }
  
  }

}
