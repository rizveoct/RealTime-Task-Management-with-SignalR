import { Routes } from '@angular/router';

export const BOARD_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () => import('./boards.component').then(m => m.BoardsComponent)
  }
];
