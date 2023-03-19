using EventsItAcademyGe.Application.Services;

namespace EventsItAcademyGe.WebAPI.Infrastructure.BackGroundWorkers
{
    public class FinisherWorker : BackgroundService
    {
        private readonly IEventService _eventService;
        public FinisherWorker(IServiceProvider provider, IConfiguration configs)
        {
            this._eventService = provider.CreateScope().ServiceProvider.GetService<IEventService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _eventService.DeleteFinishedEvent(stoppingToken);
                await Task.Delay(1000);
            }
        }
    }
}
