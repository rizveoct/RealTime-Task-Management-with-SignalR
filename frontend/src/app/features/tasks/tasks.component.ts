import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'rtm-tasks',
  imports: [CommonModule],
  template: `
    <section class="wrapper">
      <header class="header">
        <h1>Tasks</h1>
        <input placeholder="Search tasks" />
      </header>
      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Status</th>
            <th>Priority</th>
            <th>Due Date</th>
          </tr>
        </thead>
        <tbody>
          <tr *ngFor="let task of tasks">
            <td>{{ task.title }}</td>
            <td>{{ task.status }}</td>
            <td>{{ task.priority }}</td>
            <td>{{ task.dueDate }}</td>
          </tr>
        </tbody>
      </table>
    </section>
  `,
  styles: [
    `
    :host { display: block; color: #e2e8f0; }
    .wrapper { background: rgba(15, 23, 42, 0.6); padding: 1.5rem; border-radius: 1.25rem; }
    .header { display: flex; align-items: center; justify-content: space-between; margin-bottom: 1rem; }
    input {
      border-radius: 9999px;
      padding: 0.5rem 1rem;
      border: 1px solid rgba(148, 163, 184, 0.4);
      background: rgba(15, 23, 42, 0.8);
      color: inherit;
    }
    table { width: 100%; border-collapse: collapse; }
    th, td { text-align: left; padding: 0.75rem; }
    tbody tr:nth-child(even) { background: rgba(30, 41, 59, 0.65); }
    `
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TasksComponent {
  readonly tasks = [
    { title: 'Sync API contracts', status: 'In Progress', priority: 'High', dueDate: '2024-07-12' },
    { title: 'Review backlog', status: 'To Do', priority: 'Medium', dueDate: '2024-07-15' }
  ];
}
