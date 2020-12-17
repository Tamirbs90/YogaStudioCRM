import { LoginSuccessModel } from 'src/app/Models/LoginSuccessModel';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { LoginService } from './../../login/login.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  loggedInUser$: Observable<LoginSuccessModel>;

  constructor(private loginService:LoginService, private router:Router) { }

  ngOnInit(): void {
    this.loggedInUser$= this.loginService.loginSuceess$;
  }

  logout(){
    this.loginService.logout();
    this.router.navigateByUrl('/account/login');
  }

}
