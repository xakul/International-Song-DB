using ISDb.Domain.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using TrackableEntities.Common.Core;
using ISDb.Application.Util;
using System.Linq;

namespace ISDb.Application.Mssql
{
    public class BaseMssqlRepository<TEntity, TModel> : IBaseMssqlRepository<TEntity, TModel>
        where TEntity : class, ITrackable
        where TModel : class
    {

        public IUnitOfWork UnitOfWork { get; }

        public ITrackableRepository<TEntity> Repository { get; }

        public IMapper Mapper { get; }

        public BaseMssqlRepository(MssqlContext mssqlContext)
        {
            this.UnitOfWork = mssqlContext.UnitOfWork;
            this.Repository = new TrackableRepository<TEntity>(mssqlContext.BaseContext);

            this.Mapper = MappingConfig.Mapper;
        }

        public virtual void Attach(TEntity item)
            => Repository.Attach(item);

        public virtual void Delete(TEntity item)
            => Repository.Delete(item);

        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
            => await Repository.DeleteAsync(keyValues, cancellationToken).ConfigureAwait(true);

        public virtual async Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await Repository.DeleteAsync(keyValue, cancellationToken).ConfigureAwait(true);

        public virtual void Detach(TEntity item)
            => Repository.Detach(item);

        public virtual async Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
            => await Repository.ExistsAsync(keyValues, cancellationToken).ConfigureAwait(true);

        public virtual async Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await Repository.ExistsAsync(keyValue, cancellationToken).ConfigureAwait(true);

        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
            => await Repository.FindAsync(keyValues, cancellationToken).ConfigureAwait(true);

        public virtual async Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await Repository.FindAsync(keyValue, cancellationToken).ConfigureAwait(true);

        public virtual void Insert(TEntity item)
            => Repository.Insert(item);

        public virtual async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
            => await Repository.LoadPropertyAsync(item, property, cancellationToken).ConfigureAwait(true);

        public virtual IQuery<TEntity> Query()
            => Repository.Query();

        public virtual IQueryable<TEntity> Queryable()
            => Repository.Queryable();

        public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
            => Repository.QueryableSql(sql, parameters);

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(CancellationToken cancellationToken = default)
            => await Repository.Query().SelectAsync(cancellationToken).ConfigureAwait(true);

        public virtual async Task<IEnumerable<TEntity>> SelectSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
            => await Repository.Query().SelectSqlAsync(sql, parameters, cancellationToken).ConfigureAwait(true);

        public virtual void Update(TEntity item)
            => Repository.Update(item);

        public TEntity ToPoco(TModel model)
            => this.Mapper.Map<TModel, TEntity>(model);

        public TModel ToModel(TEntity item)
            => this.Mapper.Map<TEntity, TModel>(item);

        public List<TModel> ToModelList(List<TEntity> itemList)
            => this.Mapper.Map<List<TEntity>, List<TModel>>(itemList);

        public List<TEntity> ToPocoList(List<TModel> modelList)
            => this.Mapper.Map<List<TModel>, List<TEntity>>(modelList);

        public void ApplyChanges(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void AcceptChanges(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void DetachEntities(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task LoadRelatedEntities(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteSqlAsync(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
