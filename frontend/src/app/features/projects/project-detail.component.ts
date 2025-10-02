import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { inject } from '@angular/core';

@Component({
  standalone: true,
  selector: 'rtm-project-detail',
  imports: [CommonModule],
  template: `
    <section class="detail">
      <h1>Project {{ projectId }}</h1>
      <p>
        This placeholder demonstrates the project detail view. In the full implementation this will
        render project metadata, active boards, and team insights.
      </p>
    </section>
  `,
  styles: [
    `
    :host { display: block; color: #f1f5f9; }
    .detail { background: rgba(15, 23, 42, 0.65); padding: 2rem; border-radius: 1.5rem; }
    h1 { font-size: 2rem; margin-bottom: 1rem; }
    p { color: rgba(148, 163, 184, 0.95); line-height: 1.6; }
    `
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProjectDetailComponent {
  private readonly route = inject(ActivatedRoute);
  readonly projectId = this.route.snapshot.paramMap.get('id');
}
