using AvioLine.Clients.Base;
using AvioLine.Domain;
using AvioLine.Domain.Entities;
using AvioLine.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AvioLine.Clients.Services.Identity
{
    public class RolesClient :BaseClient, IRolesClient
    {
        public RolesClient() : base(ConstantAddressApi.RolesAddress)
        {
        }


        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            var result =await PostAsync($"{serviceAddress}", role);

            var ret = await result.Content.ReadAsAsync<bool>();

            return ret ? IdentityResult.Success : IdentityResult.Failed();
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public async Task<Role?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var result= await GetAsync<Role>($"{serviceAddress}/FindById/{roleId}");

            return result;
        }

        public async Task<Role?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var result = await GetAsync<Role>($"{serviceAddress}/FindByName/{normalizedRoleName}");

            return result;
        }

        public Task<string?> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetRoleId", role);

            var ret = await result.Content.ReadAsAsync<string>();

            return ret;
        }

        public async Task<string?> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await PostAsync($"{serviceAddress}/GetRoleName", role);

            var ret = await result.Content.ReadAsAsync<string>();

            return ret;
        }

        public Task SetNormalizedRoleNameAsync(Role role, string? normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(Role role, string? roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
