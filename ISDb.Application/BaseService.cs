using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application
{
    public abstract class BaseService
    {
        protected ServiceEngine ServiceEngine { get; }

        protected BaseService(ServiceEngine serviceEngine)
        {
            this.ServiceEngine = serviceEngine;

        }
    }
}
