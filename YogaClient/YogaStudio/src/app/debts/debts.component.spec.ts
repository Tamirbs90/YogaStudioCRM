import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DebtsComponent } from './debts.component';

describe('DebtsComponent', () => {
  let component: DebtsComponent;
  let fixture: ComponentFixture<DebtsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DebtsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DebtsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
