import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { environment } from 'environments/environment';

@Injectable()
export class HttpClient {

  protected readonly BASE_URL: URL = new URL(environment.serverUrl);

  constructor(
    private _http: Http
  ) { }

  public get(uri: string, baseUrl?: string): Observable<any> {
    let _headers = this.getHeader();
    return new Observable<any>(observer => {
      this._http.get(this.getEndpoint(uri), {
        headers: _headers
      }).map(response => {
        return response.json();
      }).subscribe(response => {
        observer.next(response);
        observer.complete();
      });
    });
  }

  public post(uri: string, params: any, baseUrl?: string): Observable<any> {

    return new Observable<any>(observer => {
      let headers = this.getHeader();
      this._http.post(this.getEndpoint(uri), params, {
        headers: headers
      })
      .map(response => {
        return response;
      }).subscribe(response => {
        observer.next(response);
        observer.complete();
      }, error => {
        observer.error(error);
      });
    });
  }

  public put(uri: string, params: any): Observable<Response> {
    let headers = this.getHeader();
    return this._http
      .put(this.getEndpoint(uri), JSON.stringify(params), { headers: headers });
  }

  public delete(uri: string, params: any): Observable<Response> {
    let headers = this.getHeader();
    return this._http
      .post(this.getEndpoint(uri), JSON.stringify(params), { headers: headers });
  }

  private getEndpoint(path: any): string {
    return this.BASE_URL + path;
  }

  private getHeader(): Headers {
    let headers = new Headers();
    // headers.append('Content-Type', 'application/x-www-form-urlencoded');
    headers.append('Content-Type', 'application/json');

    return headers
  }

}