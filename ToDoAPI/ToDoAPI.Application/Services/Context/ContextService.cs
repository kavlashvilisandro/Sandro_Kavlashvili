using System;
using Microsoft.Extensions.DependencyInjection;
using ToDoAPI.Infrastructure.Configuration;

namespace ToDoAPI.Application.Services.Context
{
    public static class ContextService
    {
        public static void AddContextService(this IServiceCollection collection, string ConnectionString)
        {
            collection.AddDataBaseContext(ConnectionString);
        }
    }
}
