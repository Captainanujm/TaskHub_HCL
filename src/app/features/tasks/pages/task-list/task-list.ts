import { Component } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { finalize, timeout } from 'rxjs/operators';
@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})
export class TaskList {
   tasks: Task[] = [];
  errorMessage = '';

   constructor(private service:TaskService){}

  loading = false;
   ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    this.loading = true;
    this.errorMessage = '';
    this.service.getAll().pipe(
      timeout(10000),
      finalize(() => {
        this.loading = false;
      })
    ).subscribe({
      next: (data) => {
        this.tasks = data;
      },
      error: () => {
        this.errorMessage = 'Unable to load tasks right now. Please retry in a moment.';
      }
    });
  }

  deleteTask(id: number) {
    if (confirm('Are you sure?')) {
      this.service.delete(id).subscribe(() => this.loadTasks());
    }
  }
}
