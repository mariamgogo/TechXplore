using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MobileBank.API.Infrastructure.Extensions;
using MobileBank.API.Infrastructure.Mappings;
using MobileBank.Persistence;
using MobileBank.Persistence.Context;
using MobileBank.Persistence.Seeding;
using Serilog;
using Microsoft.Extensions.Options;
using MobileBank.API.Infrastructure.Middlewares;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


//logger
builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
.CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MobileBank API",
        Version = "v1",
        Description = "API for MobileBank"
    });

    options.EnableAnnotations();
});


builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<MobileBankContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

builder.Services.RegisterMaps();  //mappings

var app = builder.Build();


app.UseGlobalExceptionHandler();  //global exception handler middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


MobileBank.API.CorsOptions corsOptions = app.Services.GetService<IOptions<MobileBank.API.CorsOptions>>()!.Value;
if (corsOptions.CorsEnabled)
{
    string[] origins = MobileBank.API.CorsOptions.GetCorsOrigins(corsOptions);
    app.UseCors(builder =>
    {
        builder.WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCulture();  //localization 

app.MapControllers();
app.UseMiddleware<LoggingMiddleware>(); //logging middleware

MobileBankSeeding.Initialize(app.Services);  // seeding
app.Run();


