import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesheetImportComponent } from './timesheet-import.component';

describe('TimesheetImportComponent', () => {
  let component: TimesheetImportComponent;
  let fixture: ComponentFixture<TimesheetImportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimesheetImportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimesheetImportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
