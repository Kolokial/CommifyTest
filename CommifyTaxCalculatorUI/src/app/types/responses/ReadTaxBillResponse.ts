import { EmployeeSalaryData } from '../data/EmployeeSalaryData';
import { BaseResponse } from './BaseResponse';

export interface ReadTaxBillResponse extends BaseResponse {
  result: EmployeeSalaryData;
}
