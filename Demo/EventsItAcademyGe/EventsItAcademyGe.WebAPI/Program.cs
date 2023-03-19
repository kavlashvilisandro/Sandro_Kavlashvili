using EventsItAcademyGe.WebAPI.Infrastructure.LoggerConfiugrations;
using EventsItAcademyGe.WebAPI.Infrastructure.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using EventsItAcademyGe.WebAPI.Infrastructure.BackGroundWorkers;

/*
 TODO:
 1.5, 2(full),
 */



var builder = WebApplication.CreateBuilder(args);

#region LoginConfiguration and AddingServices

//Loggin configurations
builder.Logging.ClearProviders();
Serilog.ILogger logger = SerilogConfiugration.ConfigureSerilog(builder.Configuration);

// Add services to the container.
builder.Services.AddServices(logger,builder.Configuration);

//Adding Background workers
builder.Services.AddHostedService<ReservationWorker>();
builder.Services.AddHostedService<FinisherWorker>();

#endregion

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region Adding JWTBearer And JWT token authentication/authorization instructions
//==========================

//it adds JWTToken Header option
builder.Services.AddSwaggerGen((SwaggerGenOptions options) =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field. example: \"Bearer {token}\"",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer((JwtBearerOptions options) =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = 
                    new SymmetricSecurityKey
                    (
                        Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT:SecretKey"))
                    ),
                ValidIssuer = builder.Configuration.GetValue<string>("JWT:Issuer"),
                ValidAudience = builder.Configuration.GetValue<string>("JWT:Audience")
            };
        });

//==========================

#endregion

var app = builder.Build();

#region Request pipeline

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddlewares();//Custom Middlewares

//If token is not authenticated, this middleware will return status 401 (UnAuthorized)
app.UseAuthentication();//This middleware authenticates jwtToken in header.

//if user is not authorized on specific data, if user does't have permission
//on action, where he wants to make his request, this middleware will return status
//403 (Forbidden)
app.UseAuthorization();//this middleware checks if user with this jwt token have access
//on specific action method, where it is going.


app.MapControllers();

app.Run();

#endregion