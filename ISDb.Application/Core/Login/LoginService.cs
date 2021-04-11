using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISDb.Application.Core.Login
{
    public class LoginService : BaseService,ILoginService
    {
       
        public LoginService(
            ServiceEngine serviceEngine) : base(serviceEngine)
        {
        }

        public async Task<LoginModel> CheckLogin(LoginModel loginModel)
        {
            var loginSucces = await this.ServiceEngine.UserService.LoginControl(loginModel.Email,loginModel.Password).ConfigureAwait(true);
            
        }
    }
}
