using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISDb.Domain.Mssql.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        int SaveChanges(CancellationToken cancellationToken = default);

    }
}
