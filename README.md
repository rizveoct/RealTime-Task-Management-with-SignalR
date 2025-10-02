# Real-Time Task Management Platform

This repository contains the foundation for a production-grade, real-time collaborative task management solution built with ASP.NET Core 8, Angular 17, and SignalR.

## Projects

- `TaskManagement.Domain` – Domain entities, value objects, and domain events.
- `TaskManagement.Application` – CQRS handlers, DTOs, validators, and MediatR behaviors.
- `TaskManagement.Infrastructure` – EF Core persistence, repositories, JWT configuration, and integrations.
- `TaskManagement.SignalRHubs` – Dedicated SignalR hubs for tasks, boards, notifications, chat, and presence.
- `TaskManagement.API` – REST API entrypoint, middleware, Swagger, and hub routing.
- `frontend/` – Angular client with Tailwind CSS, standalone components, and SignalR integration services.

## Getting Started

1. Restore .NET dependencies and create the database (migrations coming soon).
2. Configure connection strings and JWT settings in `src/TaskManagement.API/appsettings.json`.
3. Run the API: `dotnet run --project src/TaskManagement.API/TaskManagement.API.csproj`.
4. Install frontend packages from `frontend/` with `npm install` and start with `npm start`.

## Documentation

Additional documentation is available under `docs/` including architecture, ERD, API surface, deployment, and user guide previews.
