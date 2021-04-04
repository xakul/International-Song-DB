using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISDb.Domain.Mssql.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }

        protected DbSet<TEntity> Set { get; }

        public BaseRepository(DbContext context)
        {
            this.Context = context;
            this.Set = context.Set<TEntity>();

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        // After this part we are doing CRUD operations by DbSet. All of this functions exist in DbSet interface
        #region Read
        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
            => await this.Set.FindAsync(keyValues, cancellationToken);

        public virtual async Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await FindAsync(new object[] { keyValue }, cancellationToken);

        public virtual async Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            return item != null;
        }

        public virtual async Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await ExistsAsync(new object[] { keyValue }, cancellationToken);

        public virtual async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
            => await this.Context.Entry(item).Reference(property).LoadAsync(cancellationToken);

        #endregion

        #region Create
        public virtual void Insert(TEntity item)
           => this.Context.Entry(item).State = EntityState.Added;
        #endregion

        #region Update
        public virtual void Update(TEntity item)
          => this.Context.Entry(item).State = EntityState.Modified;

        public virtual void Attach(TEntity item)
            => this.Set.Attach(item);

        public virtual void Detach(TEntity item)
            => this.Context.Entry(item).State = EntityState.Detached;
        #endregion

        #region Delete
        public virtual void Delete(TEntity item)
            => this.Context.Entry(item).State = EntityState.Deleted;

        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            if (item == null) return false;
            this.Context.Entry(item).State = EntityState.Deleted;
            return true;
        }

        public virtual async Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await DeleteAsync(new object[] { keyValue }, cancellationToken);
        #endregion

        #region Query
        public virtual IQueryable<TEntity> Queryable()
            => this.Set;

        public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
            => this.Set.FromSqlRaw(sql, parameters);

        public virtual async Task<int> ExecuteSqlAsync(string sql, params object[] parameters)
            => await this.Context.Database.ExecuteSqlRawAsync(sql, parameters).ConfigureAwait(true);

        public virtual IQuery<TEntity> Query()
            => new Query<TEntity>(this);
        #endregion
    }
}
