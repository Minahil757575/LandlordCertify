using Microsoft.EntityFrameworkCore;
using LandlordBackendAPI.Data;
using LandlordBackendAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        builder => builder
            .WithOrigins("https://localhost:7234")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Access environment variables and bind to StripeSettings
builder.Services.Configure<StripSettings>(options =>
{
    options.SecretKey = Environment.GetEnvironmentVariable("Stripe__SecretKey");
    options.PublishableKey = Environment.GetEnvironmentVariable("Stripe__PublishableKey");
});

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//  Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.MapOpenApi();
//  Enable Swagger in ALL environments (not just development)
app.UseSwagger();
app.UseSwaggerUI(); // This adds Swagger UI (the browser page)

// Use the CORS policy
app.UseCors("AllowBlazor");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
