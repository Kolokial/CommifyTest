import { Component, inject, OnInit } from '@angular/core';
import { EmployeesService } from '../../services/employees/employees.service';
import { Employee } from '../../types/data/Employee';
import { MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employees-list',
  imports: [MatTableModule],
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.scss',
})
export class EmployeesListComponent implements OnInit {
  private _router = inject(Router);
  private _employeeApi = inject(EmployeesService);

  public dataSource: Employee[] = [];
  public displayedColumns: string[] = [
    'employeeFirstName',
    'employeeLastName',
    'employeeAnnualSalary',
  ];

  constructor() {}

  public ngOnInit() {
    this._employeeApi.getEmployees().subscribe((x) => {
      this.dataSource = x.result;
    });
  }

  public goToEmployeeDetailsScreen(employeeId: number) {
    this._router.navigate(['/employee', employeeId]);
  }
}
