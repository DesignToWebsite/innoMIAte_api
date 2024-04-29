using INNOMIATE_API.Data;
using INNOMIATE_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure database context
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    options.UseMySql(connectionString, serverVersion));

// Add services
builder.Services.AddScoped<UserService>();

//Add controllers
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Innomiate API",
        Description = "USER AUTHENTICATION + JOIN HACKATHON",
        Version = "v1"
    });
});

// Build the app
var app = builder.Build();

// Use Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Innomiate API V1");
    });
}

// Configure routes
app.MapControllers();

app.Run();
