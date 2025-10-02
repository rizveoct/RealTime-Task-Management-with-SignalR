import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'rtm-dashboard',
  imports: [CommonModule],
  template: `
    <section class="grid gap-6 md:grid-cols-2 xl:grid-cols-3">
      <article class="card">
        <header>
          <h2>Active Tasks</h2>
        </header>
        <p class="metric">128</p>
        <p class="hint">Across all projects</p>
      </article>
      <article class="card">
        <header>
          <h2>On Track</h2>
        </header>
        <p class="metric success">92%</p>
        <p class="hint">Completion confidence</p>
      </article>
      <article class="card">
        <header>
          <h2>Live Collaborators</h2>
        </header>
        <p class="metric">37</p>
        <p class="hint">Currently online</p>
      </article>
    </section>
  `,
  styles: [
    `
    :host { display: block; }
    .card {
      background: rgba(15, 23, 42, 0.65);
      border-radius: 1.25rem;
      padding: 1.5rem;
      box-shadow: 0 24px 48px rgba(15, 23, 42, 0.35);
      border: 1px solid rgba(148, 163, 184, 0.1);
    }
    header h2 {
      font-size: 1rem;
      font-weight: 600;
      color: #cbd5f5;
      margin-bottom: 0.75rem;
    }
    .metric {
      font-size: 2.75rem;
      font-weight: 700;
      color: #f8fafc;
      margin-bottom: 0.5rem;
    }
    .metric.success { color: #22c55e; }
    .hint {
      color: rgba(148, 163, 184, 0.9);
      font-size: 0.875rem;
    }
    `
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardComponent {}
