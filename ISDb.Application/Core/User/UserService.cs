using ISDb.Application.Mssql;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using ISDb.Application.Core.Login;

namespace ISDb.Application.Core.User
{
    public class UserService : BaseService, IUserService
    {
        private readonly BaseMssqlRepository<Domain.Mssql.Poco.User, UserModel> _mssqlRepository;

        public UserService(
            ServiceEngine serviceEngine,
             BaseMssqlRepository<Domain.Mssql.Poco.User, UserModel> mssqlRepository) : base(serviceEngine)
            {
            this._mssqlRepository = mssqlRepository;
            }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            Domain.Mssql.Poco.User user;
            UserModel createdUserModel;
            Domain.Mssql.Poco.User createdUser = new Domain.Mssql.Poco.User();

            user = this._mssqlRepository.ToPoco(userModel);

            userModel.RegisterDate = DateTime.UtcNow;

            this._mssqlRepository.Insert(user);
            await this._mssqlRepository.UnitOfWork.SaveChangesAsync();

            try
            {
                createdUser = await this._mssqlRepository.Repository
                    .Queryable()
                    .Where(a => a.Id == user.Id)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                //excpetion will be addded
            }

            if (createdUser == null)
            {
                //excpetion will be addded
            }

            createdUserModel = this._mssqlRepository.ToModel(createdUser);

            return createdUserModel;

        }

        public async Task<UserModel> LoginControl(string email, string password)
        {
            Domain.Mssql.Poco.User user = null;
            UserModel userModel;
            try
            {
                user = await this._mssqlRepository.Repository
                    .Queryable()
                    .Where(a => a.Email == email && a.Password == password)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(true);
            }
            catch
            {
                //excpetion will be addded
            }

            if (user == null)
            {
                //excpetion will be addded
            }

            userModel = this._mssqlRepository.ToModel(user);

            return userModel;

        }
    }
}
