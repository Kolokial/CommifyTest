import { Component, inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-update-employee-salary',
  imports: [],
  templateUrl: './update-employee-salary.component.html',
  styleUrl: './update-employee-salary.component.scss',
})
export class UpdateEmployeeSalaryComponent {
  data = inject(MAT_DIALOG_DATA);
}
