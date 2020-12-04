import { TestBed } from '@angular/core/testing';

import { MonthService } from './month.service';

describe('MonthService', () => {
  let service: MonthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MonthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
