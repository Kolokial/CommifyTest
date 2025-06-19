import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesListComponent } from './employees-list.component';
import { EmployeesService } from '../../services/employees/employees.service';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';

describe('EmployeesList', () => {
  let component: EmployeesListComponent;
  let fixture: ComponentFixture<EmployeesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeesListComponent],
      providers: [
        EmployeesService,
        provideHttpClient(),
        provideHttpClientTesting(),
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
