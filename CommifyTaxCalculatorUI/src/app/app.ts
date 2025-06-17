import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeesList } from './components/employees-list/employees-list';
import { EmployeesService } from './services/employees/employees.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EmployeesList],
  providers: [EmployeesService, HttpClientModule],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected title = 'CommifyTaxCalculatorUI';

  ngOnInit() {
    console.log('whaaaat');
  }
}
