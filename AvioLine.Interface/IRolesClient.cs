using AvioLine.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AvioLine.Interfaces
{
    public interface IRolesClient:IRoleStore<Role>
    {
    }
}
