import { RegisterDto } from 'src/app/Models/RegisterDto';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginSuccessModel } from 'src/app/Models/LoginSuccessModel';
import { Observable } from 'rxjs';
import { LoginService } from './../login.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  loggedInUser$= new Observable<LoginSuccessModel>();
  userExists:string='';
  registerForm= new FormGroup({
    userName: new FormControl('',Validators.required),
    password: new FormControl('', [Validators.required,Validators.minLength(8)]),
    email: new FormControl('',[Validators.required, Validators.email]),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('',Validators.required)
  });

  constructor(private loginService: LoginService, private router:Router) { }

  ngOnInit(): void {
    this.loggedInUser$= this.loginService.loginSuceess$;
  }

  register(){
    this.loginService.register(this.registerForm.value as RegisterDto).subscribe(res=>{
    this.router.navigateByUrl('/account/login');
    this.registerForm.reset();
  },
    err=>{
      this.userExists=err.error;
      setTimeout(() => {this.userExists=''},3000);
    })
  }

  wrongInput(){
    return !this.registerForm.valid;
  }

  get userName(){return this.registerForm.get('userName')};
  get password(){return this.registerForm.get('password') }
  get email(){return this.registerForm.get('email') }
  get firstName(){return this.registerForm.get('firstName') }
  get lastName(){return this.registerForm.get('lastName') }




}
