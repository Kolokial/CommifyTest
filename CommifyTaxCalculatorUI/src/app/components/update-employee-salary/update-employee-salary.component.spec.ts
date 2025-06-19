import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateEmployeeSalaryComponent } from './update-employee-salary.component';
import { EmployeesService } from '../../services/employees/employees.service';
import { MatDialogRef } from '@angular/material/dialog';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';

describe('UpdateEmployeeSalaryComponent', () => {
  let component: UpdateEmployeeSalaryComponent;
  let fixture: ComponentFixture<UpdateEmployeeSalaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateEmployeeSalaryComponent],
      providers: [
        EmployeesService,
        provideHttpClient(),
        provideHttpClientTesting(),
        MatDialogRef<UpdateEmployeeSalaryComponent>,
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(UpdateEmployeeSalaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
