import { Injectable, NgZone, signal } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { environment } from '../../../environments/environment';

export interface HubStatus {
  name: string;
  connected: boolean;
}

@Injectable({ providedIn: 'root' })
export class SignalRService {
  private readonly connections = new Map<string, HubConnection>();
  private readonly statusesSignal = signal<HubStatus[]>([]);

  readonly statuses = this.statusesSignal.asReadonly();

  constructor(private readonly zone: NgZone) {}

  connect(name: keyof typeof environment.signalR): HubConnection {
    const existing = this.connections.get(name);
    if (existing) {
      return existing;
    }

    const hubUrl = `${environment.apiUrl}${environment.signalR[name]}`;
    const connection = new HubConnectionBuilder()
      .withUrl(hubUrl)
      .withAutomaticReconnect()
      .configureLogging(LogLevel.Information)
      .build();

    connection.onclose(() => this.updateStatus(name, false));
    connection.onreconnected(() => this.updateStatus(name, true));

    this.zone.runOutsideAngular(async () => {
      try {
        await connection.start();
        this.updateStatus(name, true);
      } catch (error) {
        console.error('Failed to start hub connection', error);
        this.updateStatus(name, false);
      }
    });

    this.connections.set(name, connection);
    return connection;
  }

  private updateStatus(name: string, connected: boolean): void {
    this.zone.run(() => {
      const next = this.statusesSignal()
        .filter((status) => status.name !== name)
        .concat({ name, connected });

      this.statusesSignal.set(next);
    });
  }
}
