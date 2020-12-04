import { TestBed } from '@angular/core/testing';

import { AddpersonService } from './addperson.service';

describe('AddpersonService', () => {
  let service: AddpersonService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddpersonService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
