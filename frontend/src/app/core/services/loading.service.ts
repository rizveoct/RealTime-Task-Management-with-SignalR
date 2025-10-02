import { computed, Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LoadingService {
  private readonly requests = signal(0);

  readonly isLoading = computed(() => this.requests() > 0);

  increment(): void {
    this.requests.update((value) => value + 1);
  }

  decrement(): void {
    this.requests.update((value) => Math.max(0, value - 1));
  }
}
