using DefaultNamespace;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICarLocationService, CarLocationService>();
builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<ILocationService,LocationService>();
builder.Services.AddScoped<IRentalService,RentalService>();
builder.Services.AddScoped<DapperContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebApp v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();