import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Task } from '../../models/task.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TaskStatus } from '../../models/task.enum';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './task-form.html',
  styleUrl: './task-form.css'
})
export class TaskForm implements OnInit {

  task: Task = {
    id: 0,
    title: '',
    description: '',
    status:TaskStatus.Pending,
  };

  isEdit = false;
  submitted = false;
  readonly statusOptions = TaskStatus;

  constructor(
    private service: TaskService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    const idParam = this.route.snapshot.params['id'];

    if (idParam) {
      this.isEdit = true;
      const id = Number(idParam);
      this.service.getById(id).subscribe(res => this.task = res);
    }
  }

  save(form: any) {
    this.submitted = true;

    if (form.invalid) return;

    if (this.isEdit) {
      this.service.update(this.task.id, this.task)
        .subscribe(() => this.router.navigate(['/tasks']));
    } else {
      this.service.create(this.task)
        .subscribe(() => this.router.navigate(['/tasks']));
    }
  }
}