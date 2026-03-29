import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Task } from "../models/task.model";
@Injectable({
     providedIn:'root'

})
   
export class TaskService{
    private apiurl='/api/task'
    constructor(private http:HttpClient){}
    getAll():Observable<Task[]>{
        return this.http.get<Task[]>(this.apiurl);
    }
    getById(id:number):Observable<Task>{
        return this.http.get<Task>(`${this.apiurl}/${id}`);
    }
    update(id:number,task:Task){
        return this.http.put<Task>(`${this.apiurl}/${id}`,task);
    }
    create(task:Task){
        return this.http.post(this.apiurl,task);
    }
      delete(id: number) {
    return this.http.delete(`${this.apiurl}/${id}`);
  }
}