import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  url:string = "https://localhost:7199/api/Employee/";
  constructor(private http:HttpClient) { }

  getAllEmployees():Observable<Employee[]>{
    return this.http.get<Employee[]>(this.url);
  }

  deleteEmployee(id:number):Observable<any> {
    return this.http.delete<any>(this.url + id);
  }

  
  // createEmployee(newEmployee:Employee):Observable
}
