using AvioLine.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AvioLine.Interfaces
{
    public interface IUsersClient:
        IUserRoleStore<User>,
        IUserPasswordStore<User>,
        IUserEmailStore<User>,
        IUserClaimStore<User>,
        IUserLoginStore<User>,
        IUserTwoFactorStore<User>
        
    {
    }
}
