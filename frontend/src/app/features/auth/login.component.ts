import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'rtm-login',
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <section class="login">
      <h1>Sign in</h1>
      <form [formGroup]="form" (ngSubmit)="submit()">
        <label>
          Email
          <input type="email" formControlName="email" required />
        </label>
        <label>
          Password
          <input type="password" formControlName="password" required />
        </label>
        <button type="submit" [disabled]="form.invalid">Continue</button>
      </form>
    </section>
  `,
  styles: [
    `
    :host { display: block; }
    .login {
      max-width: 360px;
      margin: 4rem auto;
      padding: 2rem;
      border-radius: 1.5rem;
      background: rgba(15, 23, 42, 0.75);
      border: 1px solid rgba(148, 163, 184, 0.2);
      color: #f8fafc;
    }
    h1 { margin-bottom: 1.5rem; font-size: 1.75rem; }
    form { display: grid; gap: 1rem; }
    label { display: grid; gap: 0.5rem; font-size: 0.875rem; }
    input {
      background: rgba(15, 23, 42, 0.9);
      border: 1px solid rgba(148, 163, 184, 0.4);
      border-radius: 0.75rem;
      padding: 0.75rem 1rem;
      color: inherit;
    }
    button {
      margin-top: 0.5rem;
      padding: 0.75rem 1.5rem;
      border-radius: 999px;
      border: none;
      background: linear-gradient(135deg, #6366f1, #3b82f6);
      color: white;
      font-weight: 600;
      cursor: pointer;
    }
    button:disabled {
      opacity: 0.5;
      cursor: not-allowed;
    }
    `
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly form = this.fb.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  readonly submitting = signal(false);

  submit(): void {
    if (this.form.invalid) {
      return;
    }

    this.submitting.set(true);
    setTimeout(() => {
      this.authService.setToken('demo-token');
      this.submitting.set(false);
      this.router.navigate(['/dashboard']);
    }, 600);
  }
}
