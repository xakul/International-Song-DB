using ISDb.Domain.Mssql.Poco;
using ISDb.Domain.Mssql.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Mssql
{
    public class MssqlContext
    {
        public BaseContext BaseContext { get; }

        public UnitOfWork UnitOfWork { get; }

        public MssqlContext(BaseContext baseContext)
        {
            this.BaseContext = baseContext;

            this.UnitOfWork = new UnitOfWork(BaseContext);
        }
    }
}
