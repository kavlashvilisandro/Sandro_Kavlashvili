using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IServiceProvider provider) : base(provider)
        {

        }
    }
}
