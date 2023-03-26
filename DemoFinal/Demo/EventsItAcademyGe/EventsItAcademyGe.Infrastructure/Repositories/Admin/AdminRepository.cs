using EventsItAcademyGe.Domain.Models;
using EventsItAcademyGe.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EventsItAcademyGe.Domain.Exceptions;

namespace EventsItAcademyGe.Infrastructure.Repositories
{
    public class AdminRepository
    {
        private readonly EventsItAcademyGeDbContext _dbContext;
        private readonly DbSet<Admin> _dbSet;
        public AdminRepository(IServiceProvider provider)
        {
            this._dbContext = (EventsItAcademyGeDbContext)provider.GetService(typeof(EventsItAcademyGeDbContext));
            this._dbSet = _dbContext.Set<Admin>();
        }

        public async Task<int> GetAdminID(Expression<Func<Admin, bool>> where,CancellationToken token)
        {
            Admin @event = await _dbSet.Where(where).AsNoTracking().SingleOrDefaultAsync(token);
            if(@event == null)
            {
                throw new AdminNotFoundException();
            }
            return @event.AdminID;
        }
    }
}
