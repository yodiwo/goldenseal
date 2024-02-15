using GoldenSealWebApi;
using GoldenSealWebApi.Database;
using GoldenSealWebApi.DbContentMigrator;
using GoldenSealWebApi.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static GoldenSealWebApi.Middleware.ApiKeyMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the database context
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(opt => opt.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<MyHeaderFilter>();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddHostedService<DroneStateRequesterService>();
builder.Services.AddHostedService<GroundWasteSensorDataRequesterService>();

builder.Services.AddTransient<IApiKeyValidator, ApiKeyValidator>();

builder.Services.AddScoped<IDbContentMigrator, DbContentMigrator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// middleware
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// db content migrations
var applyDbContentMigrations = builder.Configuration.GetValue<bool>("ApplyDbContentMigrations");
if (applyDbContentMigrations)
	MigrateDbContent();

app.Run();



void MigrateDbContent() 
{
	using var scope = app.Services.CreateScope();
	var dbContentMigrator = scope.ServiceProvider.GetRequiredService<IDbContentMigrator>();
	dbContentMigrator.Apply();
}