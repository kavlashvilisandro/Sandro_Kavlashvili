using EventsItAcademyGe.Persistence.Context;
using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventsItAcademyGe.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected readonly EventsItAcademyGeDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(IServiceProvider provider)
        {
            this._dbContext = (EventsItAcademyGeDbContext)provider.GetService(typeof(EventsItAcademyGeDbContext));
            this._dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<int> AddAsync(T Entity,CancellationToken token)
        {
            await _dbSet.AddAsync(Entity,token);
            await _dbContext.SaveChangesAsync();
            return Entity.ID;
        }

        public virtual async Task<int> AddAsync(Action<T> instructions, CancellationToken token)
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            Attach(entity);//Unchanged
            instructions.Invoke(entity);//Modifed
            entity.ID = 0;//Modified
            await _dbContext.SaveChangesAsync(token);//Unchanged (added because ID = 0)
            return entity.ID;
        }



        //Returns tracking object by id, returns null if there is not object with this id
        public virtual async Task<T?> GetByID(int id,CancellationToken token)
        {
            return await _dbSet.Where((T entity) => entity.ID == id).SingleOrDefaultAsync(token);
        }


        //entity is not tracked
        public virtual async Task<(bool exists,T? entity)> Exists(Expression<Func<T,bool>> predicate,CancellationToken token)
        {
            /**if there is more than 2 element which satisfies this predicate, throws
            exception. if there is only one, returns this entity. if there is not
            element which satisfies this predicate, returns null**/
            T? entity = await _dbSet.Where(predicate).AsNoTracking().SingleOrDefaultAsync(token);
            if(entity == null)
            {
                return (false,entity);
            }
            return (true,entity);
        }
        public virtual async Task<List<int>> AddRangeAsync(List<T> entities,CancellationToken token)
        {
            await this._dbContext.AddRangeAsync(entities,token);
            await this._dbContext.SaveChangesAsync(token);
            List<int> Result = new List<int>();
            for(int i = 0; i < entities.Count; i++)
            {
                Result.Add(entities[i].ID);
            }
            return Result;
        }

        public virtual async Task<List<T>> SelectAsync(Expression<Func<T,bool>> expression,CancellationToken token)
        {
            List<T> Entities = await _dbSet.Where(expression).AsNoTracking().ToListAsync(token);
            return Entities;
        }
        public void Detach(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public void Attach(T entity)
        {
            _dbContext.Attach(entity);
        }



        //Returns UnTracked object
        public virtual async Task<T> UpdateAsync(int entityID, Action<T> Instruction, CancellationToken token)
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            entity.ID = entityID;
            Attach(entity);//State = UnChanged
            Instruction.Invoke(entity);//State = Modifed
            entity.ModifiedDate = DateTime.Now;//State = Modified
            await _dbContext.SaveChangesAsync(token);//entity state = UnChanged
            Detach(entity);
            return entity;
        }

        public virtual async Task SaveChangesAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }

        public virtual async Task SoftDeleteAsync(int entityID, CancellationToken token)
        {
            T entity = await _dbSet.Where(e => e.ID == entityID).SingleOrDefaultAsync(token);
            if (entity != null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.Status = (int)Statusses.Deleted;
                await _dbContext.SaveChangesAsync(token);
                Detach(entity);
            }
        }

        public virtual async Task UpdateWhere(Action<T> update, Expression<Func<T, bool>> Where, CancellationToken token)
        {
            List<T> entities = await _dbSet.Where(Where).AsTracking().ToListAsync(token);
            for(int i = 0; i < entities.Count; i++)
            {
                update.Invoke(entities[i]);
            }
            await _dbContext.SaveChangesAsync(token);
        }


    }
}
