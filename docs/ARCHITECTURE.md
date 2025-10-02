# Architecture Overview

The Real-Time Collaborative Task Management Platform follows a clean architecture approach with strict separation of concerns across five solution projects:

```text
TaskManagement.Domain        // Entities, value objects, domain events
TaskManagement.Application   // CQRS commands/queries, DTOs, validators
TaskManagement.Infrastructure// EF Core persistence, repositories, security
TaskManagement.SignalRHubs   // SignalR hubs and DI extensions
TaskManagement.API           // ASP.NET Core API surface and middleware
```

## Backend Flow

1. **API Layer** accepts HTTP or WebSocket requests and forwards them to MediatR.
2. **Application Layer** coordinates command/query handling, validation, mapping, and domain event publication.
3. **Domain Layer** encapsulates business rules for users, projects, boards, tasks, comments, attachments, notifications, and teams.
4. **Infrastructure Layer** provides EF Core persistence, repositories, JWT authentication, and Serilog logging.
5. **SignalR Layer** exposes hubs for tasks, notifications, boards, chat, and user presence.

## Frontend Flow

- Angular 17 standalone components with route-level code splitting.
- NgRx-ready state store and effects for asynchronous workflows.
- Tailwind CSS for responsive styling and dark-mode capable layouts.
- SignalR service manages hub lifecycles with automatic reconnection.

## Cross-Cutting Concerns

- Validation via FluentValidation pipeline behavior.
- MediatR-based CQRS for commands and queries.
- Domain event notifications dispatch real-time updates to SignalR hubs.
- Secure JWT authentication pipeline with extensible policies.
