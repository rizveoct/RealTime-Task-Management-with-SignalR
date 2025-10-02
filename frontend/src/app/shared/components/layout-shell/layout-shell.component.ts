import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'rtm-layout-shell',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './layout-shell.component.html',
  styleUrls: ['./layout-shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LayoutShellComponent {
  readonly navLinks = [
    { path: '/dashboard', label: 'Dashboard' },
    { path: '/projects', label: 'Projects' },
    { path: '/boards', label: 'Boards' },
    { path: '/tasks', label: 'Tasks' }
  ];
}
