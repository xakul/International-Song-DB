using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISDb.Domain.Mssql.Repository
{
    //Tentity shows that it can be generic but class
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        //Implementing some methods which we can reach with DbSet 
        #region Read
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);

        Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default);
        #endregion

        #region Create
        void Insert(TEntity item);
        #endregion

        #region Update
        void Attach(TEntity item);

        void Detach(TEntity item);
        void Update(TEntity item);
        #endregion

        #region Delete
        void Delete(TEntity item);

        Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default);
        #endregion

        #region Query
        IQueryable<TEntity> Queryable();

        IQueryable<TEntity> QueryableSql(string sql, params object[] parameters);

        Task<int> ExecuteSqlAsync(string sql, params object[] parameters);

        IQuery<TEntity> Query();
        #endregion

    }
}
