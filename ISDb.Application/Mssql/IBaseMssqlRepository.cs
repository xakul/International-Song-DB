using ISDb.Domain.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using TrackableEntities.Common.Core;

namespace ISDb.Application.Mssql
{
    public interface IBaseMssqlRepository<TEntity, TModel> : ITrackableRepository<TEntity>
        where TEntity : class, ITrackable
        where TModel : class
    {
        TEntity ToPoco(TModel model);

        TModel ToModel(TEntity item);

        List<TModel> ToModelList(List<TEntity> itemList);

        List<TEntity> ToPocoList(List<TModel> modelList);
    }
}
