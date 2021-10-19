using Data.BaseTable;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NT_Service.GenericRepository
{

    public class Repository<TEntity> : IRepository<TEntity>
     where TEntity : class
    {

        internal readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

        public Repository(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dbContext.Set<TEntity>()
                       .Where(filter);
        }
        public virtual IQueryable<TEntity> GetWithCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> Get<T>(T id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity, bool isSaveChanges = true)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            if (isSaveChanges)
            {
                await Save();
            }
        }
        public async Task AddRange(IList<TEntity> entity, bool isSaveChanges = true)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
            if (isSaveChanges)
            {
                await Save();
            }
        }


        public async Task Change(TEntity entity, bool isSaveChanges = true)
        {
            _dbContext.Set<TEntity>().Update(entity);
            if (isSaveChanges)
            {
                await Save();
            }
        }
        public async Task ChangeRange(IList<TEntity> entity, bool isSaveChanges = true)
        {
            _dbContext.Set<TEntity>().UpdateRange(entity);
            if (isSaveChanges)
            {
                await Save();
            }
        }

        public async Task Remove(TEntity entity, bool isSaveChanges = true)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (isSaveChanges)
            {
                await Save();
            }
        }

        public async Task Delete<T>(T id, bool isSaveChanges = true)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                if (isSaveChanges)
                {
                    await Save();
                }
            }

        }
        public async Task DeleteRange<T>(List<T> ids, bool isSaveChanges = true)
        {
            foreach (var item in ids)
            {
                await Delete(item, isSaveChanges);
            }
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Microsoft.EntityFrameworkCore.DbContext GetDb()
        {
            return ctx;
        }

        public IQueryable<TEntity> GetNotDeleted()
        {
            object deleted = true;
            return GetAll().Where(x => typeof(TEntity).GetProperty("IsDeleted").GetValue(x) != deleted);
        }

        public async Task SoftDelete<T>(BaseTrackable<T> entity, int id)
        {
            entity.IsDeleted = true;
            entity.DeletedBy = id;
            entity.DeletedDate = DateTime.Now.ToUniversalTime();
            await Save();
        }
        public Microsoft.EntityFrameworkCore.DbContext ctx { get; set; }


    }
}
