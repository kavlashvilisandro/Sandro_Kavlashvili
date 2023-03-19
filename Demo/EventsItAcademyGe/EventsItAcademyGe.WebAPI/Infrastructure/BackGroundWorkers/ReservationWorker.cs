using EventsItAcademyGe.Application.Services;

namespace EventsItAcademyGe.WebAPI.Infrastructure.BackGroundWorkers
{
    public class ReservationWorker : BackgroundService
    {
        private readonly IEventService _eventService;
        private readonly IConfiguration _configuration;
        public ReservationWorker(IServiceProvider provider, IConfiguration config)
        {
            //CreateScope() creates IServiceScoped and it's ServiceProvider can be used
            //to resolve only Scoped services
            this._configuration = config;
            this._eventService = provider.CreateScope().ServiceProvider.GetService<IEventService>();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _eventService.DeleteLateReservations(_configuration.GetValue<int>("ReservationTimeLimitInMinutes"), stoppingToken);
                await Task.Delay(1000);
            }
        }
    }
}
