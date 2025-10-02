# Deployment Guide (Preview)

## Prerequisites

- .NET 8 SDK
- Node.js 20+
- SQL Server (local or Azure SQL)
- Redis (optional for distributed caching)

## Backend

1. Configure connection strings and JWT secrets in `src/TaskManagement.API/appsettings.json` or environment variables.
2. Run EF Core migrations (to be added) against the target SQL Server.
3. Launch the API: `dotnet run --project src/TaskManagement.API/TaskManagement.API.csproj`.

## Frontend

1. Install dependencies: `npm install` inside the `frontend` directory.
2. Start the dev server: `npm start`.
3. Configure proxy settings to forward `/api` and `/hubs` to the ASP.NET Core backend.

## Production

- Build Angular assets using `npm run build` and serve from CDN or static hosting.
- Deploy the API to Azure App Service or containerize via Docker (compose files to be added).
- Configure CI/CD pipelines (GitHub Actions templates to be added) for automated builds, tests, and deployments.
