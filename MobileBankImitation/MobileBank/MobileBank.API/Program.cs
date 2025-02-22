using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MobileBank.API.Infrastructure.Extensions;
using MobileBank.API.Infrastructure.Mappings;
using MobileBank.Persistence;
using MobileBank.Persistence.Context;
using MobileBank.Persistence.Seeding;
using Serilog;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MobileBank.API;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
.CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<MobileBankContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

builder.Services.RegisterMaps();

var app = builder.Build();

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
app.UseCulture();

app.MapControllers();

MobileBankSeeding.Initialize(app.Services);
app.Run();


