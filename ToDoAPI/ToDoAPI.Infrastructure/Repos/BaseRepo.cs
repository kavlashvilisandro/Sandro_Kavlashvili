using System;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Persistence.Context;
using ToDoAPI.Persistence.Models.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;

namespace ToDoAPI.Infrastructure.Repos
{
    public abstract class BaseRepo<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _dbContext;

        public BaseRepo(IServiceProvider provider)
        {
            this._dbContext = (ToDoAPIDbContext)provider.GetService(typeof(ToDoAPIDbContext));
            this._dbSet = this._dbContext.Set<T>();
        }

        public async Task<int> AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item.ID;
        }


        //Predicate<T> <=> Expression<Func<T,bool>>
        public async Task<IQueryable<T>> FilterDataWithIncludes(Expression<Func<T,bool>> predicate, bool withTracking)
        {
            //? <=> null არ იქნება
            IEntityType? entityType = _dbContext.Model.FindEntityType(typeof(T));
            List<INavigation> navigations = entityType.GetNavigations().ToList();
            IQueryable<T> FilteredData = _dbSet.Where(predicate);
            for (int i = 0; i < navigations.Count; i++)
            {
                FilteredData = FilteredData.Include(navigations[i].Name);
            }
            if (!withTracking)
            {
                FilteredData = FilteredData.AsNoTracking();
            }
            return FilteredData;
        }

        public async Task<IQueryable<T>> FilterData(Expression<Func<T, bool>> predicate, bool withTracking)
        {
            IQueryable<T> FilteredData = _dbSet.Where(predicate);
            if (!withTracking)
            {
                FilteredData = FilteredData.AsNoTracking();
            }
            return FilteredData;
        }


        public async Task<List<T>> ToList(IQueryable<T> data)
        {
            return await data.ToListAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        

        public void Attach(T entity)
        {
            _dbContext.Attach(entity);
        }


        public void Detach(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}
