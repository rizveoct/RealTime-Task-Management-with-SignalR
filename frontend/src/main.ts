import { bootstrapApplication } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { environment } from './environments/environment';
import { authInterceptor } from './app/core/interceptors/auth.interceptor';
import { loadingInterceptor } from './app/core/interceptors/loading.interceptor';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideAnimations(),
    provideHttpClient(withInterceptors([authInterceptor, loadingInterceptor])),
    provideStore(),
    provideEffects([]),
    !environment.production ? provideStoreDevtools() : [],
  ],
}).catch((err) => console.error(err));
