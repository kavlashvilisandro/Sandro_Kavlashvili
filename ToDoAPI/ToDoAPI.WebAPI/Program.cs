using System.Text.Json.Serialization;
using ToDoAPI.WebAPI.Infrastructure.Extensions;
using Serilog;
using Serilog.Events;
using Serilog.Core;
using ToDoAPI.WebAPI.Logs;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();


// Add services to the container.
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions((x) =>
{
    
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.AddGlobalErrorHandler();

app.UseHttpsRedirection();

app.UseRequestLogger();

app.UseWhen((HttpContext context) => context.Request.Path.StartsWithSegments("/api/ToDo/LoggedIn"),
    (IApplicationBuilder app) =>
    {
        app.AddJWTAuthorization(builder.Configuration, builder.Configuration.GetValue<string>("JWT:UserAudience"));
    }
);
app.UseWhen((HttpContext context) => context.Request.Path.StartsWithSegments("/api/SubTasks"),
    (IApplicationBuilder app) =>
    {
        app.AddJWTAuthorization(builder.Configuration, builder.Configuration.GetValue<string>("JWT:UserAudience"));
    }
);

app.MapControllers();

app.Run();
