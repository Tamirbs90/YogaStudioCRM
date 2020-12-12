import { Observable } from 'rxjs';
import { LoginService } from '../login.service';
import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/Models/LoginDto';
import { RegisterDto } from 'src/app/Models/RegisterDto';
import { LoginSuccessModel } from 'src/app/Models/LoginSuccessModel';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  loginSuccesModel$= new Observable<LoginSuccessModel>();

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {
    this.loginSuccesModel$= this.loginService.loginSuceess$;
  }

  login(loginInfo: LoginDto){
    this.loginService.login(loginInfo).subscribe();
  }

  logout(){
    this.loginService.logout();
  }

  register(registerInfo: RegisterDto){
    this.loginService.register(registerInfo).subscribe();
  }

}
