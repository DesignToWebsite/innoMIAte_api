using innomiate_api.Models;
using innomiate_api.Services;
using innomiate_api.Services.INNOMIATE_API.Services;
using INNOMIATE_API.Data;
using INNOMIATE_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure database context
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


var policyName = "_myAllowSpecificOrigins";
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Add services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HostingRequestService>();
builder.Services.AddScoped<CompetitionService>();
builder.Services.AddScoped<CoachingManagingService>();
builder.Services.AddScoped<CompetitionCoachService>();

builder.Services.AddScoped<CompetitionParticipantService>();
builder.Services.AddScoped<BadgeService>();
builder.Services.AddScoped<StepService>();
builder.Services.AddScoped<SubmittedInputService>();

//builder.Services.AddScoped<TeamService>();
//builder.Services.AddScoped<SubmittedInputService>();
//builder.Services.AddScoped<StepsService>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<GroupService>();













//Add controllers
builder.Services.AddControllers()
            .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddCors(options => options.AddPolicy(name: policyName, builder => builder
    .WithOrigins("http://localhost:5173") 
    .AllowAnyHeader()
    .AllowAnyMethod()));

// Add distributed memory cache for session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(100));



// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Innomiate API",
        Description = "USER AUTHENTICATION + JOIN HACKATHON",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("_myAllowSpecificOrigins");

app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Innomiate API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the root URL
});

app.MapControllers();
app.UseStaticFiles();


app.Run();
