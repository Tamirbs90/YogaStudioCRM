import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchtabComponent } from './searchtab.component';

describe('SearchtabComponent', () => {
  let component: SearchtabComponent;
  let fixture: ComponentFixture<SearchtabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchtabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchtabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
