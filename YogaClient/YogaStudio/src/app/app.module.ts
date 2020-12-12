import { RouterModule } from '@angular/router';
import { ClassesService } from './Services/classes.service';
import { MonthService } from './Services/month.service';
import { PersonService } from './Services/person.service';
import { AddpersonService } from './Services/addperson.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { DatesearchComponent } from './datesearch/datesearch.component';
import { ListpageComponent } from './listpage/listpage.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { FormsModule, ReactiveFormsModule, FormControl } from '@angular/forms';
import { DebtsComponent } from './debts/debts.component';
import { ScheduleComponent } from './schedule/schedule/schedule.component';
import { SearchtabComponent } from './schedule/searchtab/searchtab.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DatesearchComponent,
    ListpageComponent,
    AddstudentComponent,
    DebtsComponent,
    ScheduleComponent,
    SearchtabComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatAutocompleteModule,
    NgbModule,
    NgbPaginationModule, 
    NgbAlertModule,
  ],
  providers: [AddpersonService,PersonService,MonthService, ClassesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
