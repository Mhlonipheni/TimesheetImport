import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TimesheetImportService } from '../providers/timesheet-import.service';

@Component({
  selector: 'app-timesheet-import',
  templateUrl: './timesheet-import.component.html',
  styleUrls: ['./timesheet-import.component.css']
})
export class TimesheetImportComponent implements OnInit {
  private subscriptions = new Subscription();
  constructor(private timesheetService: TimesheetImportService) {
  }
  sites: TimesheetImport.ITimesheetSite[] = [];
  selectedSite!: TimesheetImport.ITimesheetSite;

  ngOnInit(): void {
    this.subscriptions.add(this.timesheetService.getTimeSheetSites().subscribe(result =>{
      this.sites = result;
    }))

    this.subscriptions.add(this.timesheetService.getWeather().subscribe(result => {
      let weather = result;
    }))
  }

  siteSelected($event: string){
    let site = this.sites.find(s => s.siteId == $event);
    if(site){
      this.selectedSite = site;
    }

  }

}
