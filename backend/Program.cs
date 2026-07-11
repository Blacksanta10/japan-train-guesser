
using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


// Acts as the starup configuration only

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(); // Swagger (API testing UI)
builder.Services.AddEndpointsApiExplorer(); // generates the OpenAPI spec


// Register the database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Allow the Node.js frontend to call this API (see CORS note below)
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allowfrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // adjust to Node dev server
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});


var app = builder.Build();

// Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.MapControllers();

app.Run();
