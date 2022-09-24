import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatSelect } from '@angular/material/select';
import { FormControl } from '@angular/forms';
import { ReplaySubject, Subject } from 'rxjs';
import { take, takeUntil } from 'rxjs/operators';
import { FileUploadControl, FileUploadValidators } from '@iplab/ngx-file-upload';
import { BehaviorSubject, Subscription } from 'rxjs';
import { TimesheetImportService } from '../providers/timesheet-import.service';
import * as _ from 'lodash';
@Component({
  selector: 'app-timesheet-import',
  templateUrl: './timesheet-import.component.html',
  styleUrls: ['./timesheet-import.component.css']
})
export class TimesheetImportComponent implements OnInit {
  private subscriptions = new Subscription();
  protected _onDestroy = new Subject();
  constructor(private timesheetService: TimesheetImportService) {
  }

  selectedSite!: TimesheetImport.ITimesheetSite;

  public websiteCtrl: FormControl = new FormControl();
  public websiteFilterCtrl: FormControl = new FormControl();
  public filteredSites: ReplaySubject<TimesheetImport.ITimesheetSite[]> = new ReplaySubject(1);
  @ViewChild('singleSelect', { static: true })singleSelect!: MatSelect;

  public siteListWithoutFilter: TimesheetImport.ITimesheetSite[] = [];
  siteFilter!: string;
  clearSearchInput: boolean = true;

  allowedMediaTypes: string[] = [
    "file_extension/xlsx"
  ]
  public fileUploadControl = new FileUploadControl({ listVisible: true, multiple: false, accept: this.allowedMediaTypes}, [FileUploadValidators.accept(this.allowedMediaTypes), FileUploadValidators.filesLimit(1)]);
  public readonly uploadedFile: BehaviorSubject<string> = new BehaviorSubject("");
  ngOnInit(): void {
    this.subscriptions.add(this.timesheetService.getTimeSheetSites().subscribe(result => {
      this.siteListWithoutFilter = _.orderBy(result, 'siteName', 'asc');
      this.filterSites();
    }));
    this.subscriptions.add(this.fileUploadControl.valueChanges.subscribe((values: Array<File>) => this.getExcelFile(values[0])));
    this.websiteCtrl.setValue(this.siteListWithoutFilter[1]);
    this.filteredSites.next(this.siteListWithoutFilter.slice());
    this.subscriptions.add(this.websiteFilterCtrl.valueChanges
      .pipe(takeUntil(this._onDestroy))
      .subscribe(() => {
        this.filterSites();
      }));
  }

  ngOnChanges(changes: SimpleChanges)
  {
    if(changes['siteListWithoutFilter'].currentValue != changes['siteListWithoutFilter'].previousValue){
     
  
    
    }
  }

  ngAfterViewInit() {
    this.setInitialValue();
  }

  public clearFiles(): void {
    this.fileUploadControl.setValue([]);
  }

  public importTimesheet(){
    let file = this.fileUploadControl.value[0];
    if(file)
    {
      
    }
  }

  protected setInitialValue() {
    this.filteredSites
      .pipe(take(1), takeUntil(this._onDestroy))
      .subscribe(() => {
          this.singleSelect.compareWith = (a: TimesheetImport.ITimesheetSite, b: TimesheetImport.ITimesheetSite) => a && b && a.siteId === b.siteId;
      });
  }

  protected filterSites() {
    if (!this.siteListWithoutFilter) {
      return;
    }
  
    let search = this.websiteFilterCtrl.value;
    if (!search) {
      this.filteredSites.next(this.siteListWithoutFilter.slice());
      return;
    } else {
      search = search.toLowerCase();
    }
  
    this.filteredSites.next(
      this.siteListWithoutFilter.filter(site => site.siteName.toLowerCase().indexOf(search) > -1)
    );
  }

  private getExcelFile(file: File): void {
    if (FileReader && file) {
        const fr = new FileReader();
        let result = "";
        fr.onload = (e) => {
          if(e && e.target && e.target.result){
          this.uploadedFile.next(e.target.result.toString());
        }
        };
        fr.readAsDataURL(file);
    } else {
        this.uploadedFile.next("");
    }
  }


  ngOnDestroy() {
    this._onDestroy.next(1);
    this._onDestroy.complete();
  }
  

}
