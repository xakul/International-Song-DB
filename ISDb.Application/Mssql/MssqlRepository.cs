using ISDb.Application.Core.User;
using ISDb.Domain.Mssql.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Mssql
{
    public class MssqlRepository
    {
        private readonly MssqlContext _mssqlContext;

        private BaseMssqlRepository<Domain.Mssql.Poco.User, UserModel> _userMssqlRepository;


        public MssqlRepository(MssqlContext mssqlContext)
        {
            this._mssqlContext = mssqlContext;
        }

        public BaseMssqlRepository<Domain.Mssql.Poco.User, UserModel> UserMssqlRepository
        {
            get
            {
                if (this._userMssqlRepository != null)
                    return this._userMssqlRepository;

                this._userMssqlRepository = new BaseMssqlRepository<Domain.Mssql.Poco.User, UserModel>(_mssqlContext);
                return _userMssqlRepository;
            }
        }
    }
}
