import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestService } from './rest.service';
@Injectable({
  providedIn: 'root'
})
export class TimesheetImportService {

  constructor(private restService: RestService, private http: HttpClient) { }

  getTimeSheetSites(): Observable<TimesheetImport.ITimesheetSite[]> {
    return this.restService.get<TimesheetImport.ITimesheetSite[]>('/api/timesheetimport/GetTimesheetSites');
  }

  postExcelFile(file: File): Observable<TimesheetImport.ITimesheetImportResult> {
    return this.http.post<TimesheetImport.ITimesheetImportResult>('/api/timesheetimport/Import', file );
  }
}

