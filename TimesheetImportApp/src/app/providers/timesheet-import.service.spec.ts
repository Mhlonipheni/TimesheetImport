import { TestBed } from '@angular/core/testing';

import { TimesheetImportService } from './timesheet-import.service';

describe('TimesheetImportService', () => {
  let service: TimesheetImportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TimesheetImportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
