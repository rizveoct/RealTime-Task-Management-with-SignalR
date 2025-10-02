import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LayoutShellComponent } from './shared/components/layout-shell/layout-shell.component';

@Component({
  selector: 'rtm-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, LayoutShellComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
  title = 'Real-Time Task Management';
}
