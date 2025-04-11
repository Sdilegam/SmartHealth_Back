using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Services;
using SmartHealth_Infrastructure;
using SmartHealth_Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SmartHealthContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SmartHealthContext>();
    db.Database.Migrate();
}

app.MapGet("", async (context) => { context.Response.Redirect("http://localhost:5261/scalar"); });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("SmartHealth - Scalar")
            .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Fetch)
            .WithDarkMode(false)
            .Servers = [new ("http://localhost:8001")];
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
