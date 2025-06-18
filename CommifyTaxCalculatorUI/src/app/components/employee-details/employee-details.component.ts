import { Component, inject } from '@angular/core';
import { EmployeesService } from '../../services/employees/employees.service';
import { ActivatedRoute } from '@angular/router';
import { UpdateEmployeeSalaryComponent } from '../update-employee-salary/update-employee-salary.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-employee-details',
  imports: [],
  templateUrl: './employee-details.component.html',
  styleUrl: './employee-details.component.scss',
})
export class EmployeeDetailsComponent {
  public readonly dialog = inject(MatDialog);

  constructor(
    private _employeeService: EmployeesService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    let employeeId = this._route.snapshot.paramMap.get('id');

    this._employeeService.getEmployeeTaxBill(Number(employeeId)).subscribe({
      next: (x) => {
        console.log(x);
      },
      error: (d) => {
        console.log(d);
      },
    });
  }

  openDialog(row: any) {
    const dialogRef = this.dialog.open(UpdateEmployeeSalaryComponent, {
      data: row,
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
