using ISDb.Application.Mssql;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application
{
    public class ServiceEngine
    {
        private MssqlRepository MssqlRepository { get; }

        public ServiceEngine(MssqlRepository mssqlRepository)
        {
            this.MssqlRepository = mssqlRepository;
         }
    }
}
