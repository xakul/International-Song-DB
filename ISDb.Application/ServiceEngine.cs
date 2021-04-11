using ISDb.Application.Core.Login;
using ISDb.Application.Core.User;
using ISDb.Application.Core.UserAuth;
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

        public BaseContext context { get; }

        public ServiceEngine(BaseContext context)
        {
            this.MssqlContext = new MssqlContext(context);
            this.MssqlRepository = new MssqlRepository(this.MssqlContext);

         }

        private IUserService _userService;

        private IUserAuthService _userAuthService;

        private ILoginService _loginService;

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

        public IUserAuthService UserAuthService
        {
            get
            {
                if (this._userAuthService != null)
                    return this._userAuthService;

                this._userAuthService = new UserAuthService(this, this.MssqlRepository.UserAuthMssqlRepository);
                return this._userAuthService;
            }
        }

        public ILoginService LoginService
        {
            get
            {
                if (this._loginService != null)
                    return this._loginService;

                this._loginService = new LoginService(this);
                return this._loginService;
            }
        }
    }
}
