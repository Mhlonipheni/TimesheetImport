import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesheetSitesComponent } from './timesheet-sites.component';

describe('TimesheetSitesComponent', () => {
  let component: TimesheetSitesComponent;
  let fixture: ComponentFixture<TimesheetSitesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimesheetSitesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimesheetSitesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
