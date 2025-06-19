import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { EmployeesService } from '../../services/employees/employees.service';
import { Employee } from '../../types/data/Employee';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-employees-list',
  imports: [
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    MatPaginatorModule,
  ],
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.scss',
})
export class EmployeesListComponent implements OnInit {
  private _router = inject(Router);
  private _employeeApi = inject(EmployeesService);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  public dataSource!: MatTableDataSource<Employee>;
  public displayedColumns: string[] = [
    'employeeFirstName',
    'employeeLastName',
    'employeeAnnualSalary',
  ];

  public length: number = 0;
  public pageSize: number = 4;

  constructor() {}

  public ngOnInit() {
    this._employeeApi.getEmployees().subscribe((x) => {
      this.dataSource = new MatTableDataSource<Employee>(x.result);
      this.dataSource.paginator = this.paginator;
      this.length = Math.floor(x.result.length / this.pageSize);
    });
  }

  public goToEmployeeDetailsScreen(employeeId: number): void {
    this._router.navigate(['employee', employeeId]);
  }

  public filterEmployeeList(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
