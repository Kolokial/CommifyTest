import { Component } from '@angular/core';
import { EmployeesService } from './services/employees/employees.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterModule],
  providers: [EmployeesService],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected title = 'CommifyTaxCalculatorUI';

  ngOnInit() {}
}
