import { TestBed } from '@angular/core/testing';

import { YogaLessonService } from './yoga-lesson.service';

describe('YogaLessonService', () => {
  let service: YogaLessonService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(YogaLessonService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
