﻿using PizzaApplication.WebAPI.Infrastrucutre.Extensions;
using PizzaApplication.WebAPI.Infrastrucutre.Abstractions;



//დაუსრულებელი ნაწილი

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();



// Add services to the container.
builder.AddServicesIntoDIContainer();


BaseController.ServiceProvider = builder.Services.BuildServiceProvider();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseGlobalErrorHandler(builder);

//app.UseRequestResponseLogger(builder);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
