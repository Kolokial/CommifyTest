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
import { debounceTime, distinctUntilChanged, Subject, switchMap } from 'rxjs';

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
  public searchValue: Subject<string> = new Subject<string>();

  constructor() {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  public ngOnInit() {
    this._employeeApi.getEmployees().subscribe((x) => {
      this.dataSource = new MatTableDataSource<Employee>(x.result);

      this.dataSource.filterPredicate = (data: Employee, filter: string) => {
        return (
          data.employeeFirstName.includes(filter) ||
          data.employeeLastName.includes(filter)
        );
      };
    });

    this.searchValue.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      switchMap((term) => (this.dataSource.filter = term))
    );
  }

  public goToEmployeeDetailsScreen(employeeId: number) {
    this._router.navigate(['employee', employeeId]);
  }

  public filterEmployeeList(searchValue: Event | null): void {
    if (!searchValue) {
      return;
    }
    console.log(searchValue);
    this.searchValue.next((searchValue.target as HTMLInputElement).value);
  }
}
