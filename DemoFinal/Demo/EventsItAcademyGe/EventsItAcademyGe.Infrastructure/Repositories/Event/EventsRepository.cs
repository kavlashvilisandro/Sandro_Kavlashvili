using EventsItAcademyGe.Domain.Models;


namespace EventsItAcademyGe.Infrastructure.Repositories
{
    public class EventsRepository : BaseRepository<Event>
    {
        public EventsRepository(IServiceProvider provider) : base(provider)
        {

        }
    }
}
