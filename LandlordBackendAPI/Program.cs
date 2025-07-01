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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy => policy
            .WithOrigins("https://landlordcertify.co.uk/") // your frontend URL
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
app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();

app.UseAuthorization();


// Option 1: Simple root route
app.MapGet("/", () => "LandlordCertify API is running!");

// In Program.cs:
if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage(); // Show full error details
}
app.MapControllers();

app.Run();
