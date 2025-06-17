import { Component, OnInit } from '@angular/core';
import { EmployeesService } from '../../services/employees/employees.service';
import { Employee } from '../../types/data/Employee';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-employees-list',
  imports: [MatTableModule],
  templateUrl: './employees-list.html',
  styleUrl: './employees-list.scss',
})
export class EmployeesList implements OnInit {
  public dataSource: Employee[] = [];
  displayedColumns: string[] = [
    'employeeFirstName',
    'employeeLastName',
    'employeeAnnualSalary',
  ];

  constructor(private _employeeApi: EmployeesService) {}

  ngOnInit() {
    this._employeeApi.getEmployees().subscribe((x) => {
      this.dataSource = x.result;
    });
  }
}
