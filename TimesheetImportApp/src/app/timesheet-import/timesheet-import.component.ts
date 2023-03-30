import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatSelect } from '@angular/material/select';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReplaySubject, Subject } from 'rxjs';
import { take, takeUntil } from 'rxjs/operators';
import { FileUploadControl, FileUploadValidators } from '@iplab/ngx-file-upload';
import { BehaviorSubject, Subscription } from 'rxjs';
import { TimesheetImportService } from '../providers/timesheet-import.service';
import * as _ from 'lodash';
import { HttpEventType } from '@angular/common/http';
import { ThemePalette } from '@angular/material/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { ToastrService } from 'ngx-toastr'
@Component({
  selector: 'app-timesheet-import',
  templateUrl: './timesheet-import.component.html',
  styleUrls: ['./timesheet-import.component.css']
})
export class TimesheetImportComponent implements OnInit {
  private subscriptions = new Subscription();
  protected _onDestroy = new Subject();
  constructor(private timesheetService: TimesheetImportService,
    private toastrService: ToastrService) {
  }

  selectedSite!: TimesheetImport.ITimesheetSite;
  notifications: TimesheetImport.INotification[] = [];
  errors: TimesheetImport.INotification[] = [];
  warnings: TimesheetImport.INotification[] = [];
  timesheetDetails: TimesheetImport.ITimesheetDetail[] = [];
  public siteCtrl: FormControl = new FormControl();
  public siteFilterCtrl: FormControl = new FormControl();
  public filteredSites: ReplaySubject<TimesheetImport.ITimesheetSite[]> = new ReplaySubject(1);
  @ViewChild('singleSelect', { static: true })singleSelect!: MatSelect;

  public siteListWithoutFilter: TimesheetImport.ITimesheetSite[] = [];
  siteFilter!: string;
  clearSearchInput: boolean = true;
  fileUploadInProgress: boolean = false;
  showError: boolean = false;
  confirmEnabled: boolean = false;
  allowedMediaTypes: string[] = [
    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"
  ]
  public fileUploadControl = new FileUploadControl({ listVisible: true, multiple: false, accept: this.allowedMediaTypes}, [FileUploadValidators.accept(this.allowedMediaTypes), FileUploadValidators.filesLimit(1)]);
  public readonly uploadedFile: BehaviorSubject<string> = new BehaviorSubject("");

  color: ThemePalette = 'primary';
  mode: ProgressSpinnerMode = 'indeterminate';
  value = 90;
  ngOnInit(): void {
  
    this.subscriptions.add(this.timesheetService.getTimeSheetSites().subscribe(result => {
      this.siteListWithoutFilter = _.orderBy(result, 'siteName', 'asc');
      this.filterSites();
    }));
    this.subscriptions.add(this.fileUploadControl.valueChanges.subscribe((values: Array<File>) => this.getExcelFile(values[0])));
    this.siteCtrl.setValue(this.siteListWithoutFilter[1]);
    this.filteredSites.next(this.siteListWithoutFilter.slice());
    this.subscriptions.add(this.siteFilterCtrl.valueChanges
      .pipe(takeUntil(this._onDestroy))
      .subscribe(() => {
        this.filterSites();
      }));
  }

  ngAfterViewInit() {
    this.setInitialValue();
  }

  public clearFiles(): void {
    this.fileUploadControl.setValue([]);
    this.fileUploadControl.enable(true);
    this.notifications = [];
    this.errors = [];
    this.warnings = [];
    this.confirmEnabled = false;
  }

  public importTimesheet(){
    let file = this.fileUploadControl.value[0];
    if(file && this.siteCtrl.value)
    {
      this.fileUploadInProgress = true;
      this.showError = false;
      this.timesheetService.upload({siteId: this.siteCtrl.value.siteId, File: file}).subscribe({ 
        next: (result) => {
        if(result.type == HttpEventType.Response) {
          this.timesheetDetails = result.body?.timesheetDetails ?? [];
          this.notifications = result.body?.notifications ?? [];
          this.errors = _.filter(this.notifications, n => n.severity == 0);
          this.warnings = _.filter(this.notifications, n => n.severity == 1);
          this.confirmEnabled = !result.body?.hasErrors ?? true;
          this.fileUploadInProgress = false;
        }
      },
      error: (e) => {
        this.toastrService.error(e, "Timesheet Import", { positionClass: 'toast-top-right' });
      }});
    }
    else
    {
      this.showError = true;
      this.confirmEnabled = false;
    }
  }

  confirmTimesheet(){
    this.fileUploadInProgress = true;
    this.timesheetService.confirm(this.timesheetDetails).subscribe({
      next: (result) =>{
        this.fileUploadInProgress = false;
        if (result.success == true) {
          this.fileUploadControl.clear();
          this.fileUploadControl.enable(true);
          this.notifications = [];
          this.confirmEnabled = false;
          this.toastrService.success("Timesheet imported successfully", "Timesheet Import", { positionClass: 'toast-top-right' });
        }
        else {
          this.notifications = result.notifications;
          this.errors = _.filter(this.notifications, n => n.severity == 0);
        }
      },
      error: (e) =>{
        this.fileUploadInProgress = false;
        this.fileUploadControl.enable(true);
        this.confirmEnabled = false;
        this.toastrService.error(e, "Timesheet Import", { positionClass: 'toast-top-right' });
      }
    });

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
  
    let search = this.siteFilterCtrl.value;
    if (!search) {
      this.filteredSites.next(this.siteListWithoutFilter.slice());
      return;
    } else {
      search = search.toLowerCase();
    }
  
    this.filteredSites.next(
      this.siteListWithoutFilter.filter(site => site.siteName.toLowerCase().startsWith(search) == true)
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
        this.fileUploadControl.enable(false);
    } else {
        this.uploadedFile.next("");
    }
  }


  ngOnDestroy() {
    this._onDestroy.next(1);
    this._onDestroy.complete();
  }
  

}
