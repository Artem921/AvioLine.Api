using AvioLine.Domain.Models.Account;

namespace AvioLine.Api.Services.Abstract
{
    public interface ILoginService
    {
        /// <summary>
        /// Проверить логин и пароль
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        bool CheckLogin(LoginUserViewModel login);
    }
}
