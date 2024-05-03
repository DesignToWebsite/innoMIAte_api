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
builder.Services.AddScoped<CompetitionService>();
builder.Services.AddScoped<UserCompetitionService>();
builder.Services.AddScoped<PrizeService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<UploadImageService>();

//Add controllers
builder.Services.AddControllers()
            .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

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

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

// Build the app
var app = builder.Build();

//Use CORS
app.UseCors("AllowAllOrigins");
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
