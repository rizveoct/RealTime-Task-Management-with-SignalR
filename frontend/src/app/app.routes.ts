import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent)
  },
  {
    path: 'projects',
    loadChildren: () => import('./features/projects/projects.routes').then(m => m.PROJECT_ROUTES)
  },
  {
    path: 'boards',
    loadChildren: () => import('./features/boards/boards.routes').then(m => m.BOARD_ROUTES)
  },
  {
    path: 'tasks',
    loadChildren: () => import('./features/tasks/tasks.routes').then(m => m.TASK_ROUTES)
  },
  {
    path: 'auth',
    children: [
      {
        path: 'login',
        loadComponent: () => import('./features/auth/login.component').then(m => m.LoginComponent)
      },
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'login'
      }
    ]
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard'
  }
];
