import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import {NgxPaginationModule} from 'ngx-pagination';
@Component({
  selector: 'app-timesheet-sites',
  templateUrl: './timesheet-sites.component.html',
  styleUrls: ['./timesheet-sites.component.css']
})
export class TimesheetSitesComponent implements OnInit {
 
  constructor() { }
  @Input('original-site-list') siteListWithoutFilter: TimesheetImport.ITimesheetSite[] = [];

  @Output('site-selected') siteSelected =  new  EventEmitter<string>();
  p: number = 1;
  public sites: TimesheetImport.ITimesheetSite[] = [];
  siteFilter!: string;
  ngOnInit(): void {
    
  }

  ngOnChanges(changes: SimpleChanges)
  {
    if(changes['siteListWithoutFilter'].currentValue != changes['siteListWithoutFilter'].previousValue){
      this.sites = this.siteListWithoutFilter;
    }
  }
  filterFn()
  {
    var siteNameFilter = this.siteFilter;

    this.sites = this.siteListWithoutFilter.filter(function (el){
        return el.siteName.toString().toLowerCase().includes(
          siteNameFilter.toString().trim().toLowerCase()
        );
    });
    this.p = 1;
  }

}
