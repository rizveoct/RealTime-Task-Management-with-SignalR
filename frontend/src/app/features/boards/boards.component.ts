import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

interface BoardColumn {
  title: string;
  tasks: { id: string; title: string; assignee: string; priority: 'Low' | 'Medium' | 'High'; }[];
}

@Component({
  standalone: true,
  selector: 'rtm-boards',
  imports: [CommonModule],
  template: `
    <section class="board">
      <article class="column" *ngFor="let column of board">
        <header>
          <h2>{{ column.title }}</h2>
          <span>{{ column.tasks.length }}</span>
        </header>
        <ul>
          <li *ngFor="let task of column.tasks">
            <h3>{{ task.title }}</h3>
            <p>{{ task.assignee }}</p>
            <span class="badge" [ngClass]="task.priority.toLowerCase()">{{ task.priority }}</span>
          </li>
        </ul>
      </article>
    </section>
  `,
  styles: [
    `
    :host { display: block; }
    .board {
      display: grid;
      gap: 1.5rem;
      grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
    }
    .column {
      background: rgba(15, 23, 42, 0.6);
      border-radius: 1.25rem;
      padding: 1.25rem;
      display: flex;
      flex-direction: column;
      gap: 1rem;
    }
    header { display: flex; justify-content: space-between; align-items: center; color: #cbd5f5; }
    ul { display: flex; flex-direction: column; gap: 1rem; margin: 0; padding: 0; list-style: none; }
    li {
      background: rgba(30, 41, 59, 0.8);
      border-radius: 1rem;
      padding: 1rem;
      color: #e2e8f0;
      display: grid;
      gap: 0.5rem;
    }
    .badge {
      justify-self: flex-start;
      padding: 0.25rem 0.75rem;
      border-radius: 999px;
      font-size: 0.75rem;
      font-weight: 600;
    }
    .badge.low { background: rgba(34, 197, 94, 0.2); color: #4ade80; }
    .badge.medium { background: rgba(250, 204, 21, 0.2); color: #facc15; }
    .badge.high { background: rgba(248, 113, 113, 0.2); color: #f87171; }
    `
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BoardsComponent {
  readonly board: BoardColumn[] = [
    {
      title: 'To Do',
      tasks: [
        { id: '1', title: 'Design meeting agenda', assignee: 'Alicia Keys', priority: 'Medium' },
        { id: '2', title: 'Review QA checklist', assignee: 'Malik Ray', priority: 'High' }
      ]
    },
    {
      title: 'In Progress',
      tasks: [
        { id: '3', title: 'Implement activity feed', assignee: 'Ilya Novak', priority: 'High' }
      ]
    },
    {
      title: 'Review',
      tasks: [
        { id: '4', title: 'Finalize RBAC policies', assignee: 'Noor Faris', priority: 'High' }
      ]
    },
    {
      title: 'Done',
      tasks: [
        { id: '5', title: 'Configure CI/CD pipeline', assignee: 'Sofia Chen', priority: 'Low' }
      ]
    }
  ];
}
