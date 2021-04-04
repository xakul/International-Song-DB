using AutoMapper;
using ISDb.API.Controllers.Base;
using ISDb.Application;
using ISDb.Application.Core.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISDb.API.Controllers.User
{
    [Route("api/v1/user")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class UserController : BaseController<UserModel, UserViewModel>
    {
        private readonly ServiceEngine _serviceEngine;

        public UserController(ServiceEngine serviceEngine, IMapper mapper) : base(mapper)
        {
            this._serviceEngine = serviceEngine;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserViewModel>> CreateTopManagement(UserViewModel userViewModel)
        {
            var userModel = this.ToModel(userViewModel);
            var createdUserModel = await this._serviceEngine.UserService.CreateUser(userModel).ConfigureAwait(true);
            var createdUserViewModel = this.ToViewModel(createdUserModel);

            return Ok(createdUserViewModel);
        }


    }
}
