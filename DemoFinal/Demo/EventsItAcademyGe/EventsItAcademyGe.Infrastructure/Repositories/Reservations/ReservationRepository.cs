using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.Infrastructure.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>
    {
        public ReservationRepository(IServiceProvider provider) : base(provider)
        {

        }
    }
}
