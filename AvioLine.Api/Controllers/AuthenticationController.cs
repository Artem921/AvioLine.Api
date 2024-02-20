using AvioLine.Api.Helper;
using AvioLine.Api.Services.Abstract;
using AvioLine.Domain.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AvioLine.WebApi.Controllers;

[Route("api/Authorization")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ILoginService loginService;

    public AuthenticationController(ILoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserViewModel login)
    {
        if (login is null)
        {
            return BadRequest("Invalid user request!!!");
        }


        var result = loginService.CheckLogin(login);
        if (result)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationApplication.AppSetting["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: ConfigurationApplication.AppSetting["JWT:ValidIssuer"], audience: ConfigurationApplication.AppSetting["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new JWTTokenResponse
            {
                Token = tokenString
            });
        }
        return Unauthorized();
    }
}