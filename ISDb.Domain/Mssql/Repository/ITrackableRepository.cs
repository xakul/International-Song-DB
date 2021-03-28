using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackableEntities.Common.Core;

namespace ISDb.Domain.Mssql.Repository
{
    public interface ITrackableRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, ITrackable
    {

    }
}
