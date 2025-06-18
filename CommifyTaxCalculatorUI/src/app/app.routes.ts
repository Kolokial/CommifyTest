import { Routes } from '@angular/router';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { EmployeesListComponent } from './components/employees-list/employees-list.component';

export const routes: Routes = [
  { path: 'employees', component: EmployeesListComponent },
  {
    path: 'employee/:employeeId',
    component: EmployeeDetailsComponent,
  },
];
