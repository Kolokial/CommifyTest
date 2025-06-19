import { Component, inject, model } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import {
  AbstractControl,
  FormControl,
  FormsModule,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { EmployeesService } from '../../services/employees/employees.service';
import { ErrorResponse } from '../../types/responses/BaseResponse';

@Component({
  selector: 'app-update-employee-salary',
  imports: [
    MatDialogModule,
    FormsModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatFormFieldModule,
    ReactiveFormsModule,
  ],
  templateUrl: './update-employee-salary.component.html',
  styleUrl: './update-employee-salary.component.scss',
})
export class UpdateEmployeeSalaryComponent {
  public readonly data = inject(MAT_DIALOG_DATA);
  public salaryFormControl = new FormControl(0, [
    this.getPositiveNumberValidator(),
  ]);
  public currentSalary: number = 0;
  public apiErrors: string[] = [];

  private _dialogRef = inject(MatDialogRef<UpdateEmployeeSalaryComponent>);
  private _employeeService = inject(EmployeesService);

  ngOnInit() {
    this.currentSalary = this.data.currentSalary;
  }

  public updateSalary() {
    if (!this.salaryFormControl.value) {
      return;
    }
    this._employeeService
      .updateEmployeeSalary(this.data.employeeId, this.salaryFormControl.value)
      .subscribe({
        next: () => {
          this._dialogRef.close(this.salaryFormControl.value);
        },
        error: (errors: ErrorResponse[]) => {
          this.apiErrors = [...errors.map((e) => e.errorMessage)];
        },
      });
  }

  private getPositiveNumberValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (Number(control.value) < 0) {
        return { negative: true };
      } else {
        return null;
      }
    };
  }
}
