using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.CustomeConstraints;
using TaskFlow.Api.Middlewares;
using TaskFlow.Share.Contracts;
using TaskFlow.Shared.Entities;
using TaskFlow.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("csguid", typeof(IdCustomeConstraint));
});
builder.Services.AddTransient<LoggingMiddleware>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("http://localhost:5036")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCustomLogging();

app.UseRouting();
app.UseCors("AllowBlazor");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
