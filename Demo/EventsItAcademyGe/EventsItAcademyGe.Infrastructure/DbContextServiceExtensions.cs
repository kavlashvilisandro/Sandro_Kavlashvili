using Microsoft.Extensions.DependencyInjection;
using EventsItAcademyGe.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EventsItAcademyGe.Infrastructure
{
    public static class DbContextServiceExtensions
    {
        public static void AddEventsItAcademyGeDbContext(this IServiceCollection service,string connectionString)
        {
            service.AddDbContext<EventsItAcademyGeDbContext>((DbContextOptionsBuilder builder) =>
            {
                builder.UseSqlServer(connectionString);
            });
        }
    }
}
