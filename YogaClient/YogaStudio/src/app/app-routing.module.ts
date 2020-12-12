import { DebtsComponent } from './debts/debts.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListpageComponent } from './listpage/listpage.component';
import { ScheduleComponent } from './schedule/schedule/schedule.component';

const routes: Routes = [
{path:'students',component: ListpageComponent},
{path:'add',component: AddstudentComponent},
{path:'debts', component:DebtsComponent},
{path: 'schedule', component:ScheduleComponent },
{path: 'account', loadChildren: ()=>import("./login/account.module").then(mod=>mod.AccountModule)},
{path:'', redirectTo:'/account/login', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
