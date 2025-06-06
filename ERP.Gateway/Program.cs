using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services to the container
builder.Services.AddOcelot();

// Add CORS policy for microservices
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Add logging
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAll");

// Add a health check endpoint for the gateway itself
app.MapGet("/gateway/health", () => 
{
    return Results.Ok(new { 
        Status = "Healthy", 
        Service = "ERP.Gateway",
        Timestamp = DateTime.UtcNow 
    });
});

// Use Ocelot middleware
await app.UseOcelot();

app.Run();
