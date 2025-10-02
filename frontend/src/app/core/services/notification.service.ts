import { Injectable, signal } from '@angular/core';
import { SignalRService } from './signalr.service';

export interface NotificationMessage {
  id: string;
  title: string;
  message: string;
  timestamp: string;
  read: boolean;
}

@Injectable({ providedIn: 'root' })
export class NotificationService {
  private readonly notificationsSignal = signal<NotificationMessage[]>([]);
  readonly notifications = this.notificationsSignal.asReadonly();

  constructor(private readonly signalRService: SignalRService) {
    const connection = this.signalRService.connect('notificationHub');
    connection.on('NotificationReceived', (payload: NotificationMessage) => {
      this.notificationsSignal.update((notifications) => [payload, ...notifications]);
    });
  }

  markAsRead(id: string): void {
    this.notificationsSignal.update((notifications) =>
      notifications.map((notification) =>
        notification.id === id ? { ...notification, read: true } : notification
      )
    );
  }
}
