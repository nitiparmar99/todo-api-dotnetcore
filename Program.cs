using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowLocalAngular",
        policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});

// Register services
builder.Services.AddSingleton<ITodoService, TodoService>();

var app = builder.Build();

app.UseCors("AllowLocalAngular");

app.MapControllers();

app.Run("http://localhost:5000");
