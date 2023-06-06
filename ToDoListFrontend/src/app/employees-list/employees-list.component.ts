import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee';
import { ToDoListService } from '../to-do-list.service';
import { ToDo } from '../to-do';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  
  employees:Employee[] = [];
  todos:ToDo[] = [];

  constructor(private api:EmployeeService, private todoApi:ToDoListService){}

  ngOnInit(): void {
    this.api.getAllEmployees().subscribe(
      (result) => {
        this.employees = result;
        this.todoApi.getToDoList().subscribe(
          (result) => {
            this.todos = result;
            this.fillOutToDos();
          }
        )
      }
    )
  }

  //The Backend wants to be passed the id
  //The frontend will have an easier time with the index
  deleteEmployee(id:number, index:number){
    let toDos:ToDo[] = this.employees[index].toDos;
    if(toDos.length > 0 || toDos){
      for(let i = 0; i < this.todos.length; i++){
        this.todoApi.deleteToDo(toDos[i].id).subscribe(
          () => {
            toDos.splice(index, 1);
          }
        )
      }
  }
    this.api.deleteEmployee(id).subscribe(
      () => {
        this.employees.splice(index, 1);
      }
    )
  }

  fillOutToDos(){
    for(let i = 0; i<this.employees.length; i++){
      
      this.employees[i].toDos = this.todoApi.getToDosByEmployee(this.employees[i].id, this.todos);
    }
  }
}
