var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// 1. Add Swagger generation services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Enable Swagger in ALL environments (so it works on Render)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API v1");
    c.RoutePrefix = string.Empty; // Serves Swagger UI at the root URL (https://your-app.onrender.com)
});

// 3. Commented out to prevent infinite HTTPS redirect loops on Render
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();