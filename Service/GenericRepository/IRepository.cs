using Data.BaseTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NT_Service.GenericRepository
{
    
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetNotDeleted();
        Task<TEntity> Get<T>(T id);

        Task Add(TEntity entity, bool isSaveChanges = true);

        Task Change(TEntity entity, bool isSaveChanges = true);

        Task ChangeRange(IList<TEntity> entity, bool isSaveChanges = true);

        Task Delete<T>(T id, bool isSaveChanges = true);
        Task DeleteRange<T>(List<T> ids, bool isSaveChanges = true);
        Task AddRange(IList<TEntity> entity, bool isSaveChanges = true);
        Task Save();
        Microsoft.EntityFrameworkCore.DbContext GetDb();

        Task SoftDelete<T>(BaseTrackable<T> entity, int by);
        Task Remove(TEntity entity, bool isSaveChanges = true);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

    }
}
