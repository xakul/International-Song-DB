using AutoMapper;
using ISDb.Application.Core.User;
using ISDb.Domain.Mssql.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Util
{
    public class UserModelProfile : Profile
    {
         public UserModelProfile ()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
