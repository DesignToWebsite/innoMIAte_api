using INNOMIATE_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
var connectionString = "server=localhost;user=root;password=;database=INNOMIATE";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<UserDb>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );



builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("items"));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Innomiate API",
        Description = "USER AUTHENTIFICATION + JOIN HACKATHON",
        Version = "v1"
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
         "/swagger/v1/swagger.json",
         "Innomiate API V1");
    });
}




//Return the list of users
app.MapGet("/users", async (UserDb db) => await db.Users.ToListAsync());

//Create a new user
app.MapPost("/user", async (UserDb db, User user) =>
{
    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Created($"/user/{user.Id}", user);
});

//GET a single user
app.MapGet("/user/{id}", 
        async (UserDb db, int id) => 
            await db.Users.FindAsync(id)
        );

// Update  user

app.MapPut("/pizza/{id}", async (UserDb db, User updateuser, int id) =>
{
      var user = await db.Users.FindAsync(id);
      if (user is null) return Results.NotFound();
      user.FirstName = updateuser.FirstName;
      user.LastName = updateuser.LastName;
      user.UserName = updateuser.UserName;
      user.Email = updateuser.Email;
      user.Bio = updateuser.Bio;
      await db.SaveChangesAsync();
      return Results.NoContent();
});


// Delete an item

app.MapDelete("/user/{id}", async (UserDb db, int id) =>
{
   var user = await db.Users.FindAsync(id);
   if (user is null)
   {
      return Results.NotFound();
   }
   db.Users.Remove(user);
   await db.SaveChangesAsync();
   return Results.Ok();
});


app.Run();
