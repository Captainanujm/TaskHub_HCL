import { Routes } from '@angular/router';
import { TaskForm } from './features/tasks/pages/task-form/task-form';
import { TaskList } from './features/tasks/pages/task-list/task-list';
export const routes: Routes = [
  { path: '', redirectTo: 'tasks', pathMatch: 'full' },
  { path: 'tasks', component: TaskList },
  { path: 'create', component: TaskForm},
  { path: 'edit/:id', component: TaskForm },
  { path: '**', redirectTo: 'tasks' }
];
