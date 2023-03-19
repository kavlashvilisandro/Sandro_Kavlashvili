using Microsoft.Extensions.DependencyInjection;
using EventsItAcademyGe.Infrastructure;
namespace EventsItAcademyGe.Application
{
    public static class DbContextAdding
    {
        public static void AddDbContexts(this IServiceCollection service, string connectionString)
        {
            service.AddEventsItAcademyGeDbContext(connectionString);
        }
    }
}
