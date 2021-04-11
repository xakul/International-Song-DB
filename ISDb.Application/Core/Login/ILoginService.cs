using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Core.Login
{
    public interface ILoginService
    {
        Task<LoginModel> CheckLogin(LoginModel loginModel);
    }
}
