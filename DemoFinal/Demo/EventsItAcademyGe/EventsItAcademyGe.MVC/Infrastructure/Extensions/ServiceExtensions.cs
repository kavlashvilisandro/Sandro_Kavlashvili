using EventsItAcademyGe.MVC.Infrastructure.Clients;


namespace EventsItAcademyGe.MVC.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddHttpClient<EventsItAcademyGePublicClient>((HttpClient client) =>
            {
                //AddHttpClient adds with scoped lifetime and automatically disposes
                //after object is cleared from memmorry
                client.BaseAddress = new Uri("https://localhost:7225/");
            });

            services.AddHttpClient<EventsItAcademyGeUserClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri("https://localhost:7225/");
            });

            services.AddHttpClient<EventsItAcademyGeAdminClient>((HttpClient client) => {
                client.BaseAddress = new Uri("https://localhost:7225/");
            });
        }
    }
}
