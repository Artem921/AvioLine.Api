using AvioLine.Api.Services.Abstract;
using AvioLine.Domain.Models.Account;

namespace AvioLine.Api.Services
{
    public class LoginService : ILoginService
    {

        public bool CheckLogin(LoginUserViewModel login)
        {
            if ("Admin".Equals(login.UserName) && "Aa1.".Equals(login.Password))
            {
                return true;
            }
            return false;

        }

    }
}

