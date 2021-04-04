using ISDb.Application.Core.User;
using ISDb.Application.Mssql;
using ISDb.Domain.Mssql.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application
{
    public class ServiceEngine
    {
        private MssqlRepository MssqlRepository { get; }
        protected MssqlContext MssqlContext { get; }

        public readonly BaseContext baseContext;

        public ServiceEngine()
        {

            this.MssqlContext = new MssqlContext(this.baseContext);
            this.MssqlRepository = new MssqlRepository(this.MssqlContext);

         }

        private IUserService _userService;

        public IUserService UserService
        {
            get
            {
                if (this._userService != null)
                    return this._userService;

                this._userService = new UserService(this,this.MssqlRepository.UserMssqlRepository);
                return this._userService;
            }
        }
    }
}
