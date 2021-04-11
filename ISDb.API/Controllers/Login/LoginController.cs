using AutoMapper;
using ISDb.API.Controllers.Base;
using ISDb.API.Controllers.User;
using ISDb.Application;
using ISDb.Application.Core.Login;
using ISDb.Application.Core.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISDb.API.Controllers.Login
{
    [Route("api/v1/login")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class LoginController : BaseController<UserModel, UserViewModel>                              
    {
        private readonly ServiceEngine _serviceEngine;

        public LoginController(ServiceEngine serviceEngine, IMapper mapper) : base(mapper)
        {
            this._serviceEngine = serviceEngine;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> RegisterUser(LoginViewModel loginViewModel)
        {
            var createdUserModel = await this._serviceEngine.UserService.LoginControl(loginViewModel.Email, loginViewModel.Password).ConfigureAwait(true);
            var createdUserViewModel = this.ToViewModel(createdUserModel);

            return Ok(createdUserViewModel);
        }


    }
}
