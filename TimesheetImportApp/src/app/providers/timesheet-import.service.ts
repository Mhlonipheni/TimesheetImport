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

  getWeather(): Observable<WeatherForecast[]> {
    return this.http.get<WeatherForecast[]>('/api/weatherforecast/Get');
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
