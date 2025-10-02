# API Surface

## Authentication

- `POST /api/v1/auth/register` – Register a new user (to be implemented).
- `POST /api/v1/auth/login` – Authenticate user and issue JWT/refresh tokens (to be implemented).

## Tasks

- `POST /api/v1/tasks` – Create a task and broadcast a `TaskCreatedEvent`.
- `GET /api/v1/tasks/{taskId}` – Retrieve task details.

## SignalR Hubs

- `/hubs/tasks` – Task updates, assignments, checklist changes.
- `/hubs/notifications` – Real-time notifications for assignments and mentions.
- `/hubs/boards` – Board synchronization and ordering events.
- `/hubs/chat` – Task comment stream with typing indicators.
- `/hubs/presence` – Online/offline presence broadcast.

Swagger/OpenAPI is enabled in development for inspection at `/swagger`.
