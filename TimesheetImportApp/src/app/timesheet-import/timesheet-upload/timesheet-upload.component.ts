import { Component, Input, OnInit } from '@angular/core';
import { FileUploadControl, FileUploadValidators } from '@iplab/ngx-file-upload';
import { BehaviorSubject, Subscription } from 'rxjs';
@Component({
  selector: 'app-timesheet-upload',
  templateUrl: './timesheet-upload.component.html',
  styleUrls: ['./timesheet-upload.component.css']
})
export class TimesheetUploadComponent implements OnInit {
  constructor() { }
  private subscription: Subscription = new Subscription;
  @Input('selected-site') selectedSite!: TimesheetImport.ITimesheetSite;
  allowedMediaTypes: string[] = [
    "file_extension/xlsx"
  ]
  public fileUploadControl = new FileUploadControl({ listVisible: true, multiple: false, accept: this.allowedMediaTypes}, [FileUploadValidators.accept(this.allowedMediaTypes), FileUploadValidators.filesLimit(1)]);
  public readonly uploadedFile: BehaviorSubject<string> = new BehaviorSubject("");
  ngOnInit(): void {
    this.subscription = this.fileUploadControl.valueChanges.subscribe((values: Array<File>) => this.getExcelFile(values[0]));
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
