using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Persistence.Context;

namespace ToDoAPI.Infrastructure.Configuration
{
    public static class ContextConfiguration
    {
        public static void AddDataBaseContext(this IServiceCollection collection, string ConnectionString)
        {
            collection.AddDbContext<ToDoAPIDbContext>((DbContextOptionsBuilder builder) =>
            {
                builder.UseSqlServer(ConnectionString);
            });
        }
    }
}
