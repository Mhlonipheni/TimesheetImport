import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import {NgxPaginationModule} from 'ngx-pagination';
import { FileUploadModule } from '@iplab/ngx-file-upload';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';

import { AppComponent } from './app.component';

import { TimesheetImportComponent } from './timesheet-import/timesheet-import.component';
import { TimesheetSitesComponent } from './timesheet-import/timesheet-sites/timesheet-sites.component';
import { TimesheetUploadComponent } from './timesheet-import/timesheet-upload/timesheet-upload.component';

@NgModule({
  declarations: [
    AppComponent,
    TimesheetImportComponent,
    TimesheetSitesComponent,
    TimesheetUploadComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    FileUploadModule,
    BrowserAnimationsModule,
    MatSelectModule,
    MatButtonModule,
    MatFormFieldModule,
    NgxMatSelectSearchModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
