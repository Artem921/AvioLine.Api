using AvioLine.Domain.Entities;
using Azure;
using Microsoft.AspNetCore.Identity;

namespace AvioLine.Data
{
    public class IdentityInitializer
    {
        /// <summary>
        /// Добавление пользователя admin в бд
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public static void Initialize(UserManager<User> userManager, RoleManager<Role> roleManager)
        {

         
            if ( roleManager.FindByNameAsync(Role.Admin).Result == null)
            {
                 roleManager.CreateAsync(new Role { Name = Role.Admin }).Wait();
            }

            if (roleManager.FindByNameAsync(Role.User).Result == null)
            {
                roleManager.CreateAsync(new Role { Name = Role.User }).Wait();
            }


            if ( userManager.FindByNameAsync(User.Admin).Result == null)
            {
                var admin = new User { UserName=User.Admin };
                var result =  userManager.CreateAsync(admin, User.AdminPassword).Result;

        

                if (result.Succeeded)
                {
              
                     userManager.AddToRoleAsync(admin, Role.Admin).Wait();
                }
            }
        }
    }
}