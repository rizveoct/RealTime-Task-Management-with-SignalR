using Microsoft.AspNetCore.Mvc;
using Serilog;
using TaskManagement.API.Extensions;
using TaskManagement.Application;
using TaskManagement.Infrastructure;
using TaskManagement.SignalRHubs;
using TaskManagement.SignalRHubs.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddSignalRHubs();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), StatusCodes.Status500InternalServerError));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>())
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseGlobalExceptionHandling();
app.UseHttpsRedirection();
app.UseCors("Default");
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapHub<TaskHub>("/hubs/tasks");
app.MapHub<NotificationHub>("/hubs/notifications");
app.MapHub<BoardHub>("/hubs/boards");
app.MapHub<ChatHub>("/hubs/chat");
app.MapHub<PresenceHub>("/hubs/presence");

app.Run();
