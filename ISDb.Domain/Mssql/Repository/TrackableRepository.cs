using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrackableEntities.Common.Core;

namespace ISDb.Domain.Mssql.Repository
{
    public class TrackableRepository<TEntity> : BaseRepository<TEntity>, ITrackableRepository<TEntity>
     where TEntity : class, ITrackable
    {
        public TrackableRepository(DbContext context) : base(context)
        {

        }

        public override void Insert(TEntity item)
        {
            item.TrackingState = TrackingState.Added;
            base.Insert(item);
        }

        public override void Update(TEntity item)
        {
            item.TrackingState = TrackingState.Modified;
            base.Update(item);
        }

        public override void Delete(TEntity item)
        {
            item.TrackingState = TrackingState.Deleted;
            base.Delete(item);
        }

        public override async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            if (item == null) return false;
            item.TrackingState = TrackingState.Deleted;
            this.Context.Entry(item).State = EntityState.Deleted;
            return true;
        }
        #region Query
        public virtual IQueryable<TEntity> Queryable()
            => this.Set;

        public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
            => this.Set.FromSqlRaw(sql, parameters);

        public virtual async Task<int> ExecuteSqlAsync(string sql, params object[] parameters)
            => await this.Context.Database.ExecuteSqlRawAsync(sql, parameters).ConfigureAwait(true);

        public virtual IQuery<TEntity> Query()
            => new Query<TEntity>(this);

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
        #endregion
    }
}
