using AvioLine.Helper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AvioLine.Services
{
	public class JWTProvider
	{
		public static string GenerateToken(string username)
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationApplication.AppSetting["JWT:Secret"]));

			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var tokeOptions = new JwtSecurityToken(issuer: ConfigurationApplication.AppSetting["JWT:ValidIssuer"],
												  audience: ConfigurationApplication.AppSetting["JWT:ValidAudience"],
												  claims: new List<Claim> { new Claim(ClaimTypes.Email, username) },
												  expires: DateTime.Now.AddDays(10), signingCredentials: signinCredentials); ;

			var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
			return tokenString;
		}
	}
}
