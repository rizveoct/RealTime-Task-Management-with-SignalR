import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly tokenSignal = signal<string | null>(null);

  get token(): string | null {
    return this.tokenSignal();
  }

  setToken(token: string | null): void {
    this.tokenSignal.set(token);
  }
}
