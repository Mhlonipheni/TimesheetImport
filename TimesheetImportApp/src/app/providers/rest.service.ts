import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpParams, HttpHeaders } from '@angular/common/http'

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestService {
 
  constructor(private httpClient: HttpClient) {

   }
   get<T>(url: string, options?: RestServiceRequestOptions): Observable<T> {
    var httpUrl = this.getUrl(url);

    return this.httpClient.get<T>(httpUrl, { ...options, observe: 'body', responseType: 'json' });
}

post<T>(url: string, body: any | null, options?: RestServiceRequestOptions): Observable<T> {
    var httpUrl = this.getUrl(url);

    return this.httpClient.post<T>(httpUrl, body, { ...options, observe: 'body', responseType: 'json' });
}

getBlob(url: string, options?: RestServiceRequestOptions): Observable<HttpEvent<Blob>> {
    var httpUrl = this.getUrl(url);

    return this.httpClient.get(httpUrl, { ...options, observe: 'events', responseType: 'blob', reportProgress: true });
}

postBlob(url: string, body: any | null, options?: RestServiceRequestOptions): Observable<HttpEvent<Blob>> {
    var httpUrl = this.getUrl(url);

    return this.httpClient.post(httpUrl, body, { ...options, observe: 'events', responseType: 'blob', reportProgress: true });
}

private getUrl(url: string) {
    var fullUrl = url;

    return fullUrl;
}
}

export interface RestServiceRequestOptions {
headers?: HttpHeaders | {
    [header: string]: string | string[];
};
observe?: string;
params?: HttpParams | {
    [param: string]: string | string[];
};
reportProgress?: boolean;
responseType?: string;
withCredentials?: boolean;
}

