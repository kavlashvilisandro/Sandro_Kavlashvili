using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using System.Text.Json;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Middlewares
{
    public class DataValidationMiddleware
    {
        private readonly Serilog.ILogger _logger;
        private readonly RequestDelegate _next;

        public DataValidationMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            this._logger = logger;
            this._next = next;
        }

        //if there is not IValidator of specific type, it continiues
        //without validation
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            using (StreamReader reader = new StreamReader(context.Request.Body))
            {
                string data = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
                Endpoint endPoint = context.GetEndpoint();
                if (endPoint == null)
                {
                    await _next.Invoke(context);
                    return;
                }
                ControllerActionDescriptor descriptor = endPoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                if (descriptor == null)
                {
                    await _next.Invoke(context);
                    return;
                }
                MethodInfo actionMethodInfo = descriptor.MethodInfo;

                ParameterInfo[] parameters = actionMethodInfo.GetParameters();
                ParameterInfo modelInfo = null;
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType != typeof(CancellationToken))
                    {
                        modelInfo = parameters[i];
                        break;
                    }
                }
                if (modelInfo == null)
                {
                    await _next.Invoke(context);
                    return;
                }
                Type validatorType = typeof(IValidator<>).MakeGenericType(modelInfo.ParameterType);
                IValidator validator = (IValidator)context.RequestServices.GetService(validatorType);
                //validator is null if there is not service with type of validatorType
                if (validator == null)
                {
                    await _next.Invoke(context);
                    return;
                }
                var RequestObject = JsonSerializer.Deserialize(data, modelInfo.ParameterType);

                var validationContext = new ValidationContext<object>(RequestObject);
                var validationResult = await validator.ValidateAsync(validationContext);
                if (!validationResult.IsValid)
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(validationResult.Errors));
                    return;
                }
                await _next.Invoke(context);
            }
        }

    }
}
