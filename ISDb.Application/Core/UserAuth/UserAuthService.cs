using ISDb.Application.Mssql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDb.Application.Core.UserAuth
{
    public class UserAuthService : BaseService, IUserAuthService
    {
        private readonly BaseMssqlRepository<Domain.Mssql.Poco.UserAuth, UserAuthModel> _mssqlRepository;

        public UserAuthService(
    ServiceEngine serviceEngine,
     BaseMssqlRepository<Domain.Mssql.Poco.UserAuth, UserAuthModel> mssqlRepository) : base(serviceEngine)
        {
            this._mssqlRepository = mssqlRepository;
        }

        public async Task<UserAuthModel> CreateUserAuth(UserAuthModel userAuthModel)
        {
            Domain.Mssql.Poco.UserAuth userAuth;
            UserAuthModel createdUserAuthModel;
            if (userAuthModel == null)
            {
                //exception will be added
            }

            userAuth = this._mssqlRepository.ToPoco(userAuthModel);
            this._mssqlRepository.Insert(userAuth);

            try
            {
                userAuth = await this._mssqlRepository.Repository
                    .Queryable()
                    .Where(a => a.UserId == userAuth.UserId)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(true);
            }
            catch
            {
                //excpetion will be addded
            }

            if (userAuth == null)
            {
                //excpetion will be addded
            }

            createdUserAuthModel = this._mssqlRepository.ToModel(userAuth);

            return createdUserAuthModel;
        }

        public async Task<bool> CheckIsUserAdmin(string userId)
        {
            Domain.Mssql.Poco.UserAuth userAuth = null;

            try
            {
                userAuth = await this._mssqlRepository.Repository
                    .Queryable()
                    .Where(a => a.UserId == userId)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                //excpetion will be addded
            }

            if (userAuth.IsAdmin)
                return true;
            else
                return false;

        }
    }
}
