using AutoMapper;
using ISDb.API.Controllers.User;
using ISDb.Application.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISDb.API.Util
{
    public class UserModelViewProfile : Profile
    {
        public UserModelViewProfile()
        {
            CreateMap<UserModel, UserViewModel>().ReverseMap();
        }
    }
}
