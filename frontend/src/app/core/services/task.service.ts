import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

export interface TaskModel {
  id: string;
  title: string;
  description?: string;
  priority: string;
  status: string;
  dueDateUtc?: string;
  boardId: string;
}

@Injectable({ providedIn: 'root' })
export class TaskService {
  private readonly baseUrl = `${environment.apiUrl}/api/v1/tasks`;

  constructor(private readonly http: HttpClient) {}

  create(task: Partial<TaskModel>): Observable<TaskModel> {
    return this.http.post<TaskModel>(this.baseUrl, task);
  }

  getById(id: string): Observable<TaskModel> {
    return this.http.get<TaskModel>(`${this.baseUrl}/${id}`);
  }
}
