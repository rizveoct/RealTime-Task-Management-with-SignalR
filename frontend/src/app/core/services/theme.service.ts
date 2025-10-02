import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  private readonly darkModeSignal = signal<boolean>(true);

  readonly isDarkMode = this.darkModeSignal.asReadonly();

  toggle(): void {
    this.darkModeSignal.update((value) => !value);
    document.body.classList.toggle('dark', this.darkModeSignal());
  }
}
