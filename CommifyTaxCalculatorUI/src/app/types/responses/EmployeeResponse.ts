import { Employee } from '../data/Employee';
import { BaseResponse } from './BaseResponse';

export interface EmployeeResponse extends BaseResponse {
  result: Employee;
}
