import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
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

  upload(fileUploadRequest: TimesheetImport.FileUploadRequest): Observable<HttpEvent<TimesheetImport.ITimesheetImportResult>> {
    const formData: FormData = new FormData();

    formData.append('file', fileUploadRequest.File);
    formData.append('siteId', fileUploadRequest.siteId);
    const req = new HttpRequest('POST', '/api/timesheetimport/Import', formData, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }

  confirm(timesheetDetails: TimesheetImport.ITimesheetDetail[]): Observable<HttpEvent<TimesheetImport.ITimesheetImportConfirmationResult>> {
    
    const req = new HttpRequest('POST', '/api/timesheetimport/ConfirmImport', timesheetDetails);
    return this.http.request(req);
  }
}

