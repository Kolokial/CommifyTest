import {
  HttpClientTestingModule,
  HttpTestingController,
  provideHttpClientTesting,
} from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import {
  HttpClient,
  HttpErrorResponse,
  HttpEventType,
  HttpHeaders,
  HttpResponse,
  provideHttpClient,
} from '@angular/common/http';
import { BaseApi } from './BaseApi';
import { of, throwError } from 'rxjs';
import { ErrorResponse } from '../../types/responses/BaseResponse';

class TestApi extends BaseApi {
  getCleanUrl(url: string) {
    return (this as any).cleanUpUrl(url);
  }

  simulateErrorHandling(error: HttpErrorResponse | ErrorResponse) {
    const fn = this.catchErrorWrapper;
    return fn(error, of(null)).subscribe({
      error: (e) => (this.lastError = e),
    });
  }

  lastError: any = null;
}

describe('BaseApi', () => {
  let api: TestApi;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient(), provideHttpClientTesting()],
    });
    const http = TestBed.inject(HttpClient);
    api = new TestApi(http, '/api');
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should remove leading slashes from URL', () => {
    expect(api.getCleanUrl('/Employee')).toBe('Employee');
    expect(api.getCleanUrl('Employee')).toBe('Employee');
  });

  it('should unwrap nested error.errors correctly', () => {
    const simulatedError: HttpErrorResponse = {
      error: {
        errors: [
          {
            errorMessage: "'Employee Id' must be greater than or equal to '1'.",
          },
        ],
      },
      name: 'HttpErrorResponse',
      message: '',
      ok: false,
      headers: new HttpHeaders(),
      status: 0,
      statusText: '',
      url: null,
      type: HttpEventType.ResponseHeader,
    };

    api.simulateErrorHandling(simulatedError);
    expect(api.lastError).toEqual([
      {
        errorMessage: "'Employee Id' must be greater than or equal to '1'.",
      },
    ]);
  });

  it('should unwrap error.error correctly if no .errors key', () => {
    const simulatedError: HttpErrorResponse = {
      error: {
        error: {
          errors: [
            {
              errorMessage: "Employee Id '19' does not exist!",
            },
          ],
        },
      },
      name: 'HttpErrorResponse',
      message: '',
      ok: false,
      headers: new HttpHeaders(),
      status: 0,
      statusText: '',
      url: null,
      type: HttpEventType.ResponseHeader,
    };

    api.simulateErrorHandling(simulatedError);
    expect(api.lastError).toEqual(simulatedError.error);
  });

  it('should fallback to raw error object if no error property', () => {
    const simulatedError = new HttpErrorResponse({
      status: 404,
      statusText: 'Not Found',
      url: '/api/missing',
    });

    api.simulateErrorHandling(simulatedError);
    expect(api.lastError).toBe(simulatedError);
  });
});
