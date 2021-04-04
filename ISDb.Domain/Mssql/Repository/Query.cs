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
    public class Query<TEntity> : IQuery<TEntity> where TEntity : class
    {
        private int? skip;
        private int? take;
        private IQueryable<TEntity> query;
        private IOrderedQueryable<TEntity> orderedQuery;

        public Query(IBaseRepository<TEntity> repository) => query = repository.Queryable();

        public virtual IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
            => Set(q => q.query = q.query.Where(predicate));

        public virtual IQuery<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
            => Set(q => q.query = q.query.Include(navigationProperty));

        public virtual IQuery<TEntity> Include(string navigationPropertyPath)
            => Set(q => q.query = q.query.Include(navigationPropertyPath));

        public virtual IQuery<TEntity> OrderBy(Expression<Func<TEntity, object>> keySelector)
        {
            if (this.orderedQuery == null)
                this.orderedQuery = this.query.OrderBy(keySelector);
            else
                this.orderedQuery.OrderBy(keySelector);
            return this;
        }

        public virtual IQuery<TEntity> ThenBy(Expression<Func<TEntity, object>> thenBy)
            => Set(q => q.orderedQuery.ThenBy(thenBy));

        public virtual IQuery<TEntity> OrderByDescending(Expression<Func<TEntity, object>> keySelector)
        {
            if (this.orderedQuery == null)
                this.orderedQuery = this.query.OrderByDescending(keySelector);
            else
                this.orderedQuery.OrderByDescending(keySelector);
            return this;
        }

        public virtual IQuery<TEntity> ThenByDescending(Expression<Func<TEntity, object>> thenByDescending)
            => Set(q => q.orderedQuery.ThenByDescending(thenByDescending));

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
            => await this.query.CountAsync(cancellationToken);

        public virtual IQuery<TEntity> Skip(int skip)
            => Set(q => q.skip = skip);

        public virtual IQuery<TEntity> Take(int take)
            => Set(q => q.take = take);

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken = default)
        {
            this.query = this.orderedQuery ?? this.query;

            if (this.skip.HasValue) this.query = this.query.Skip(this.skip.Value);
            if (this.take.HasValue) this.query = this.query.Take(this.take.Value);

            return await this.query.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            => await this.query.FirstOrDefaultAsync(predicate, cancellationToken);

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            => await this.query.SingleOrDefaultAsync(predicate, cancellationToken);

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            => await this.query.AnyAsync(predicate, cancellationToken);

        public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
            => await this.query.AnyAsync(cancellationToken);

        public virtual async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            => await this.query.AllAsync(predicate, cancellationToken);

        public virtual async Task<IEnumerable<TEntity>> SelectSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
            => await (this.query as DbSet<TEntity>)?.FromSqlRaw(sql, parameters).ToListAsync(cancellationToken);

        private IQuery<TEntity> Set(Action<Query<TEntity>> setParameter)
        {
            setParameter(this);
            return this;
        }
    }
}
