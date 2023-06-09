import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ToDo } from './to-do';

@Injectable({
  providedIn: 'root'
})
export class ToDoListService {

  url:string = "https://localhost:7199/api/Task/";
  constructor(private http:HttpClient) { }

  getToDoList():Observable<ToDo[]>{
    return this.http.get<ToDo[]>(this.url);
  }

  getToDosByEmployee(employeeId:number, todos:ToDo[] ):any{
    
    let output:ToDo[] = []; 
    for(let i = 0; i < todos.length; i++){
      if(todos[i].assignedTo === employeeId){
        output.push(todos[i]);
      }
    }
​
    return output;
  }

  getToDo(id:number):Observable<ToDo>{
    return this.http.get<ToDo>(this.url + id);
  }

  createToDo(newToDo:ToDo):Observable<void>{
    return this.http.post<void>(this.url, newToDo);
  }

  deleteToDo(id:number):Observable<void>{
    return this.http.delete<void>(this.url + id);
  } 
}
