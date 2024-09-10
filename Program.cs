using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Register controllers

// Add Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register book repository and services (dependency injection)
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>(); // Register BookService

// Add logging (optional, for error handling/logging)
builder.Services.AddLogging(); // If needed for logging in ErrorHandlingMiddleware

// Add OAuth 2.0 (JWT Bearer) Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://accounts.google.com"; // OAuth provider's authority
        options.Audience = "213763084556-9iroquc101eb6145hcd5v4a6dpl8jua2.apps.googleusercontent.com"; // Replace with your actual client ID
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

// Add authorization policies
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add custom error-handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

//app.UseHttpsRedirection();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map controllers to handle API routes
app.MapControllers();

app.Run();
