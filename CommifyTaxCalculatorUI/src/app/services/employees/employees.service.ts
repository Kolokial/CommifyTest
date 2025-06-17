import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeesResponse } from '../../types/responses/EmployeesResponse';

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  constructor(private _http: HttpClient) {}

  public getEmployees(): Observable<EmployeesResponse> {
    return this._http.get<EmployeesResponse>(`/api/Employees`);
  }
}
