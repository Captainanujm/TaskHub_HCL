using Microsoft.EntityFrameworkCore;
using TaskHub.Models;
using TaskHub.Repositories;
using TaskHub.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskdbContext>(options =>
    options.UseMySQL(connectionString)
);
builder.Services.AddScoped<ITaskRepo, TaskRepo>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
