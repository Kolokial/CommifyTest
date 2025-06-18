import { Routes } from '@angular/router';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { EmployeesListComponent } from './components/employees-list/employees-list.component';

export const routes: Routes = [
  {
    path: 'employee/:employeeId',
    component: EmployeeDetailsComponent,
    pathMatch: 'full',
    title: 'Employee Details',
  },
  {
    path: 'employees',
    component: EmployeesListComponent,
    pathMatch: 'full',
    title: 'Employees List',
  },
  { path: '**', redirectTo: 'employees' },
];
