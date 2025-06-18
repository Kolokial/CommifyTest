import { Component } from '@angular/core';
import { EmployeesService } from './services/employees/employees.service';
import { EmployeesListComponent } from './components/employees-list/employees-list.component';

@Component({
  selector: 'app-root',
  imports: [EmployeesListComponent],
  providers: [EmployeesService],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected title = 'CommifyTaxCalculatorUI';

  ngOnInit() {}
}
