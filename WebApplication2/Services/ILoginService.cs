using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Login;

namespace YogaStudio.Services
{
    public interface ILoginService
    {
        Task<LoginSuccessModel> Login(LoginDto loginRequest);
        Task<LoginSuccessModel> Register(RegisterDto registerRequest);

        Task Logout();
    }
}
