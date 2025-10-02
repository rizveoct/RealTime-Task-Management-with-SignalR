import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  standalone: true,
  selector: 'rtm-projects',
  imports: [CommonModule, RouterLink],
  template: `
    <header class="header">
      <h1>Projects</h1>
      <button type="button">New Project</button>
    </header>
    <section class="grid">
      <article class="tile" *ngFor="let project of projects">
        <h2>{{ project.name }}</h2>
        <p>{{ project.description }}</p>
        <a [routerLink]="['/projects', project.id]">Open</a>
      </article>
    </section>
  `,
  styles: [
    `
    :host { display: block; color: #e2e8f0; }
    .header { display: flex; align-items: center; justify-content: space-between; margin-bottom: 1.5rem; }
    h1 { font-size: 2rem; font-weight: 700; }
    button {
      background: linear-gradient(135deg, #3b82f6 0%, #6366f1 100%);
      border: none;
      color: white;
      padding: 0.75rem 1.5rem;
      border-radius: 9999px;
      cursor: pointer;
      font-weight: 600;
    }
    .grid {
      display: grid;
      gap: 1.25rem;
      grid-template-columns: repeat(auto-fill, minmax(260px, 1fr));
    }
    .tile {
      background: rgba(15, 23, 42, 0.6);
      border-radius: 1rem;
      padding: 1.25rem;
      border: 1px solid rgba(148, 163, 184, 0.1);
    }
    a {
      color: #38bdf8;
      text-decoration: none;
      font-weight: 600;
    }
    `
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProjectsComponent {
  readonly projects = [
    { id: '1', name: 'Customer Onboarding', description: 'Streamline customer onboarding experience.' },
    { id: '2', name: 'Mobile Redesign', description: 'Revamp the mobile application workflow.' }
  ];
}
