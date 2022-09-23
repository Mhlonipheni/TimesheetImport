import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { FileUploadControl, FileUploadValidators } from '@iplab/ngx-file-upload';
import { BehaviorSubject, Subscription } from 'rxjs';
import  * as _ from "lodash";
@Component({
  selector: 'app-timesheet-upload',
  templateUrl: './timesheet-upload.component.html',
  styleUrls: ['./timesheet-upload.component.css']
})
export class TimesheetUploadComponent implements OnInit {
  constructor() { }
  subscription: Subscription = new Subscription;
  @Input('original-site-list') siteListWithoutFilter: TimesheetImport.ITimesheetSite[] = [];
  allowedMediaTypes: string[] = [
    "file_extension/xlsx"
  ]
  public fileUploadControl = new FileUploadControl({ listVisible: true, multiple: false, accept: this.allowedMediaTypes}, [FileUploadValidators.accept(this.allowedMediaTypes), FileUploadValidators.filesLimit(1)]);
  public readonly uploadedFile: BehaviorSubject<string> = new BehaviorSubject("");
  
  selectedValue: string = "-1";

  foods: Food[] = [
    {value: 'steak-0', viewValue: 'Steak'},
    {value: 'pizza-1', viewValue: 'Pizza'},
    {value: 'tacos-2', viewValue: 'Tacos'},
  ];
  
  ngOnInit(): void {
    this.subscription = this.fileUploadControl.valueChanges.subscribe((values: Array<File>) => this.getExcelFile(values[0]));
  }

  ngOnChanges(changes: SimpleChanges)
  {
    if(changes['siteListWithoutFilter'].currentValue != changes['siteListWithoutFilter'].previousValue){
      this.siteListWithoutFilter =  _.orderBy(this.siteListWithoutFilter, ['siteName'], "asc");
      this.siteListWithoutFilter.splice(0, 0, {siteId:'-1', siteName:'None'});
    }
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

}

interface Food {
  value: string;
  viewValue: string;
}

