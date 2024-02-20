﻿using AvioLine.Dal;
using AvioLine.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvioLine.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesApiController : ControllerBase
    {
        private readonly RoleStore<Role> roleStore;

        public RolesApiController(IdentityContext context) => roleStore = new RoleStore<Role>(context);

        [HttpGet("AllRoles")]
        public async Task<IEnumerable<Role>> GetAllRoles() => await roleStore.Roles.ToArrayAsync();

        [HttpPost]
        public async Task<bool> CreateAsync(Role role) => (await roleStore.CreateAsync(role)).Succeeded;

        [HttpPost("GetRoleId")]
        public async Task<string> GetRoleIdAsync(Role role) => await roleStore.GetRoleIdAsync(role);

        [HttpPost("GetRoleName")]
        public async Task<string> GetRoleNameAsync(Role role) => await roleStore.GetRoleNameAsync(role);

        [HttpGet("FindById/{id}")]
        public async Task<Role> FindByIdAsync(string id) => await roleStore.FindByIdAsync(id);

        [HttpGet("FindByName/{name}")]
        public async Task<Role> FindByNameAsync(string name) => await roleStore.FindByNameAsync(name);


    }
}
