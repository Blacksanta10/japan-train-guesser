
// Acts as the starup configuration only

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();

// Controllers (Important for real APIs)
builder.Services.AddController();

// Swagger (API testing UI)
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Swagger in development
if (AppContext.Envionment.IsDevlopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
