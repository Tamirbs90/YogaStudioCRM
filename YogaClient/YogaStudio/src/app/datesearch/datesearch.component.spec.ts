import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatesearchComponent } from './datesearch.component';

describe('DatesearchComponent', () => {
  let component: DatesearchComponent;
  let fixture: ComponentFixture<DatesearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatesearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatesearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
