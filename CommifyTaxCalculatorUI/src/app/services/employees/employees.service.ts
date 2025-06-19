import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeesResponse } from '../../types/responses/EmployeesResponse';
import { ReadTaxBillResponse } from '../../types/responses/ReadTaxBillResponse';
import { BaseApi } from './BaseApi';
import { EmployeeResponse } from '../../types/responses/EmployeeResponse';

@Injectable({
  providedIn: 'root',
})
export class EmployeesService extends BaseApi {
  constructor(private _http: HttpClient) {
    super(_http, '/api');
  }

  public getEmployees(): Observable<EmployeesResponse> {
    return this.getRequest<EmployeesResponse>(`Employees`);
  }

  public getEmployee(id: number): Observable<EmployeeResponse> {
    const searchParams = new HttpParams().set('id', `${id}`);
    return this.getRequest('Employee', searchParams);
  }

  public getEmployeeTaxBill(id: number): Observable<ReadTaxBillResponse> {
    const searchParams = new HttpParams().set('id', `${id}`);
    return this.getRequest<ReadTaxBillResponse>(
      'Employee/ReadTaxBill',
      searchParams
    );
  }

  public updateEmployeeSalary(id: number, newSalary: number): Observable<void> {
    return this.patchRequest('Employee/UpdateSalary', {
      employeeId: id,
      newSalary: newSalary,
    });
  }
}
