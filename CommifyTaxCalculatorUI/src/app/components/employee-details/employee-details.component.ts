import { Component, inject, signal } from '@angular/core';
import { EmployeesService } from '../../services/employees/employees.service';
import { ActivatedRoute } from '@angular/router';
import { UpdateEmployeeSalaryComponent } from '../update-employee-salary/update-employee-salary.component';
import { MatCardModule } from '@angular/material/card';
import { MatDialog } from '@angular/material/dialog';
import { MatSortModule } from '@angular/material/sort';
import { EmployeeSalaryDataDisplay as EmployeeTaxData } from '../../types/EmployeeTaxBillView';
import { EmployeeSalaryData } from '../../types/data/EmployeeSalaryData';
import { CommonModule } from '@angular/common';
import { Employee } from '../../types/data/Employee';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { ErrorResponse } from '../../types/responses/BaseResponse';

@Component({
  selector: 'app-employee-details',
  imports: [
    MatSortModule,
    MatCardModule,
    CommonModule,
    MatIconModule,
    MatDividerModule,
  ],
  templateUrl: './employee-details.component.html',
  styleUrl: './employee-details.component.scss',
})
export class EmployeeDetailsComponent {
  public readonly dialog = inject(MatDialog);
  public taxData: EmployeeTaxData[] = [];
  public employee!: Employee;
  public errors!: ErrorResponse[];

  constructor(
    private _employeeService: EmployeesService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    let employeeId = this._route.snapshot.paramMap.get('employeeId');

    this._employeeService.getEmployee(Number(employeeId)).subscribe({
      next: (x) => {
        this.employee = x.result;
      },
      error: (errors: ErrorResponse[]) => {
        this.errors.push(...errors);
      },
    });

    this.fetchTaxData(Number(employeeId));
  }

  private fetchTaxData(employeeId: number): void {
    this._employeeService.getEmployeeTaxBill(Number(employeeId)).subscribe({
      next: (x) => {
        this.taxData.push(...this.mapToEmployeeTaxData(x.result));
      },
      error: (errors: ErrorResponse[]) => {
        this.errors.push(...errors);
      },
    });
  }

  openDialog() {
    const dialogRef = this.dialog.open(UpdateEmployeeSalaryComponent, {
      data: {
        currentSalary: this.employee.employeeAnnualSalary,
        employeeId: this.employee.employeeId,
      },
    });

    dialogRef.afterClosed().subscribe((newSalary: number) => {
      if (Number(newSalary) > 0) {
        this.taxData = [];
        this.employee.employeeAnnualSalary = newSalary;
        this.fetchTaxData(this.employee.employeeId);
      }
    });
  }

  private mapToEmployeeTaxData(
    salaryData: EmployeeSalaryData
  ): EmployeeTaxData[] {
    const data = [];
    data.push(
      ...[
        { name: 'Gross Annual Salary', value: salaryData.grossAnnualSalary },
        { name: 'Gross Monthly Salary', value: salaryData.grossMonthlySalary },
        { name: 'Net Annual Salary', value: salaryData.netAnnualSalary },
        { name: 'Net Monthly Salary', value: salaryData.netMonthlySalary },
        { name: 'Annual Tax Paid', value: salaryData.annualTaxPaid },
        { name: 'Monthly Tax Paid', value: salaryData.monthlyTaxPaid },
      ]
    );
    return data;
  }
}
