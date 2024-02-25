using AvioLine.Clients.Base;
using AvioLine.Domain;
using AvioLine.Domain.DTO.Identity;
using AvioLine.Domain.Entities;
using AvioLine.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace AvioLine.Clients.Services.Identity
{
    public class UsersClient:BaseClient,IUsersClient
    {
        private readonly ILogger<UsersClient> logger;

        public UsersClient(ILogger<UsersClient> logger) :base(ConstantAddressApi.UsersAddress)
        {
            this.logger = logger;
        }

        public  Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
           
           return PostAsync($"{ serviceAddress}/AddClaims",new AddClaimDTO() { User = user, Claims = claims });
        }

        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            return PostAsync($"{serviceAddress}/AddLogin", new AddLoginDTO() { User = user, LoginInfo = login });
        }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            return PostAsync($"{serviceAddress}/Role/{roleName}", user);
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            logger.LogInformation("Создан пользователь", user.UserName);
            var result=await PostAsync($"{serviceAddress}/User", user);
            var ret = await result.Content.ReadAsAsync<bool>();
            return ret ? IdentityResult.Success : IdentityResult.Failed();


        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return GetAsync<User>($"{serviceAddress}/User/Find/{userId}");
        }

        public Task<User?> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
           
            return await GetAsync<User>($"{serviceAddress}/User/Normal/{normalizedUserName}");
        }

        public async Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            var result= await PostAsync($"{serviceAddress}/GetClaims",user);

            return await result.Content.ReadAsAsync<List<Claim>>();
        }

        public async Task<string?> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetEmail", user);

            return await result.Content.ReadAsAsync<string>();
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetLogin", user);

            return await result.Content.ReadAsAsync<List<UserLoginInfo>>();
        }

        public Task<string?> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetNormalUserName", user);

            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<string?> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetPasswordHash", user);

            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/Roles", user);
       
            return await result.Content.ReadAsAsync<List<string>>();
        }

        public async Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {

            var result = await PostAsync($"{serviceAddress}/GetTwoFactorEnabled", user);

            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            
            var result = await PostAsync($"{serviceAddress}/UserId", user);
     
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<string?> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/UserName", user);

            return await result.Content.ReadAsAsync<string>();
        }

        public async  Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetUsersForClaim", claim);

            return await result.Content.ReadAsAsync<List<User>>();
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var result= await PostAsync($"{serviceAddress}/inrole/{roleName}", user);
			return await result.Content.ReadAsAsync<bool>();
		}

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string? email, CancellationToken cancellationToken)
        {
            user.Email = email;

            return PostAsync($"{serviceAddress}/SetEmail/{email}", user);

        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public   Task SetNormalizedEmailAsync(User user, string? normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;

            return PostAsync($"{serviceAddress}/SetNormalEmail/{normalizedEmail}", user);
        }

        public Task SetNormalizedUserNameAsync(User user, string? normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;

            return PostAsync($"{serviceAddress}/SetNormalUserName/{normalizedName}", user);


        }

        public async Task SetPasswordHashAsync(User user, string? passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash= passwordHash;

            await PostAsync($"{serviceAddress}/SetPasswordHash", new PasswordHashDTO { User=user,Hash=passwordHash});

        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled= enabled;

            return PostAsync($"{serviceAddress}/SetTwoFactor/{enabled}", user);

        }

        public Task SetUserNameAsync(User user, string? userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;

             return PostAsync($"{serviceAddress}/UserName/{userName}", user);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var result = await PutAsync($"{serviceAddress}/UserUpdate", user);
            var ret = await result.Content.ReadAsAsync<bool>();
            return ret ? IdentityResult.Success : IdentityResult.Failed();
        }
    }
}
