import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UpdateEmployeeSalaryComponent } from './update-employee-salary.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeesService } from '../../services/employees/employees.service';
import { of, throwError } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';

describe('UpdateEmployeeSalaryComponent', () => {
  let component: UpdateEmployeeSalaryComponent;
  let fixture: ComponentFixture<UpdateEmployeeSalaryComponent>;
  let mockEmployeeService: jasmine.SpyObj<EmployeesService>;
  let mockDialogRef: jasmine.SpyObj<
    MatDialogRef<UpdateEmployeeSalaryComponent>
  >;

  beforeEach(async () => {
    mockEmployeeService = jasmine.createSpyObj('EmployeesService', [
      'updateEmployeeSalary',
    ]);
    mockDialogRef = jasmine.createSpyObj('MatDialogRef', ['close']);

    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, UpdateEmployeeSalaryComponent],
      providers: [
        { provide: EmployeesService, useValue: mockEmployeeService },
        { provide: MatDialogRef, useValue: mockDialogRef },
        {
          provide: MAT_DIALOG_DATA,
          useValue: { employeeId: 1, currentSalary: 50000 },
        },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(UpdateEmployeeSalaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should initialize currentSalary from dialog data', () => {
    expect(component.currentSalary).toBe(50000);
  });

  it('should not call service if salary is invalid or zero', () => {
    component.salaryFormControl.setValue(null);
    component.updateSalary();
    expect(mockEmployeeService.updateEmployeeSalary).not.toHaveBeenCalled();
  });

  it('should call updateEmployeeSalary and close dialog on success', () => {
    component.salaryFormControl.setValue(60000);
    mockEmployeeService.updateEmployeeSalary.and.returnValue(of(void 0));

    component.updateSalary();

    expect(mockEmployeeService.updateEmployeeSalary).toHaveBeenCalledWith(
      1,
      60000
    );
    expect(mockDialogRef.close).toHaveBeenCalledWith(60000);
  });

  it('should set apiErrors on service failure', () => {
    const mockErrors = [{ errorMessage: 'Something went wrong' }];
    component.salaryFormControl.setValue(60000);
    mockEmployeeService.updateEmployeeSalary.and.returnValue(
      throwError(() => mockErrors)
    );

    component.updateSalary();

    expect(component.apiErrors).toContain('Something went wrong');
  });

  it('should validate positive number correctly', () => {
    const validator = (component as any).getPositiveNumberValidator();
    expect(validator({ value: -5 })).toEqual({ negative: true });
    expect(validator({ value: 0 })).toBeNull();
    expect(validator({ value: 100 })).toBeNull();
  });
});
