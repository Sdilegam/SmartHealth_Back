using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using IntermediateLab_Backend.Application.Interfaces.Security;
using IntermediateLab_Backend.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Security;
using SmartHealth_Application.Services;
using SmartHealth_Infrastructure;
using SmartHealth_Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new DateTimeConverter()));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
    {
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
    }
);
// builder.Services.AddControllers();
builder.Services.AddDbContext<SmartHealthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Main")));


builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IMedecineService, MedecineService>();
builder.Services.AddScoped<IMedecineRepository, MedecineRepository>();

TokenManager.Config config = new()
{
    Audience = builder.Configuration["Jwt:Audience"],
    Duration = int.Parse(builder.Configuration["Jwt:Duration" ?? "60"]),
    Issuer = builder.Configuration["Jwt:Issuer"],
    Secret = builder.Configuration["Jwt:Secret"],
};
builder.Services.AddSingleton<ITokenManager, TokenManager>(_ => new TokenManager(config));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(b => b.AddDefaultPolicy(o =>
{
    o.AllowAnyMethod();
    o.AllowAnyOrigin();
    o.AllowAnyHeader();
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidAudience = config.Audience,
        ValidateIssuer = true,
        ValidIssuer = config.Issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret))
    });
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SmartHealthContext>();

    if (app.Environment.IsDevelopment())
    {
        db.Database.EnsureDeleted();
        // db.Database.EnsureCreated();
    }
    db.Database.Migrate();
}

var port = app.Configuration["Host:Port"];

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapGet("", async (context) => { context.Response.Redirect($"http://localhost:{port}/scalar"); });
}

app.UseSwagger(options => { options.RouteTemplate = "/openapi/{documentName}.json"; });
app.UseSwagger();
app.MapScalarApiReference();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.GetString() != null)
        {
            return DateTime.Parse(reader.GetString()!);
        }
        else
        {
            return default;
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // writer.WriteStringValue(value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
        // writer.WriteStringValue(value.ToLocalTime());
    }
}