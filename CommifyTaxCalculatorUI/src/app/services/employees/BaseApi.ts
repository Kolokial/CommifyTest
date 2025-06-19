import {
  HttpClient,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { ErrorResponse } from '../../types/responses/BaseResponse';

export abstract class BaseApi {
  constructor(protected http: HttpClient, private _baseUrl: string) {}

  protected getRequest<T>(
    url: string,
    searchParams?: HttpParams
  ): Observable<T> {
    return this.http
      .get<T>(`${this._baseUrl}/${this.cleanUpUrl(url)}`, {
        params: searchParams,
      })
      .pipe(catchError(this.catchErrorWrapper));
  }

  protected postRequest<T, R>(url: string, body: T): Observable<R> {
    return this.http
      .post<R>(
        `${this._baseUrl}/${this.cleanUpUrl(url)}`,
        JSON.stringify(body),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .pipe(catchError(this.catchErrorWrapper));
  }

  protected patchRequest<T, P>(url: string, body: T): Observable<P> {
    return this.http
      .patch<P>(`${this._baseUrl}/${this.cleanUpUrl(url)}`, body, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .pipe(catchError(this.catchErrorWrapper));
  }

  protected deleteRequest<T>(url: string): Observable<T> {
    return this.http
      .delete<T>(`${this._baseUrl}/${this.cleanUpUrl(url)}`)
      .pipe(catchError(this.catchErrorWrapper));
  }

  protected cleanUpUrl(url: string): string {
    return url.startsWith('/') ? url.substring(1) : url;
  }
  protected catchErrorWrapper<T>(error: any, caught: Observable<T>) {
    if (error?.error?.errors) {
      return throwError(() => error.error.errors as ErrorResponse);
    } else if (error?.error) {
      return throwError(() => error.error as ErrorResponse);
    }

    return throwError(() => error as HttpErrorResponse);
  }
}
