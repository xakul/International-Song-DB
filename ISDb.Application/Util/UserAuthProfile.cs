using AutoMapper;
using ISDb.Application.Core.UserAuth;
using ISDb.Domain.Mssql.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Util
{
    public class UserAuthProfile : Profile
    {
        public UserAuthProfile()
        {
            CreateMap<UserAuthModel, UserAuth>().ReverseMap();
        }
    }
}
