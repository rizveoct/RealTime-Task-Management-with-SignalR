import { HttpEvent, HttpInterceptorFn } from '@angular/common/http';
import { finalize, Observable } from 'rxjs';
import { inject } from '@angular/core';
import { LoadingService } from '../services/loading.service';

export const loadingInterceptor: HttpInterceptorFn = (req, next): Observable<HttpEvent<unknown>> => {
  const loadingService = inject(LoadingService);
  loadingService.increment();

  return next(req).pipe(
    finalize(() => loadingService.decrement())
  );
};
