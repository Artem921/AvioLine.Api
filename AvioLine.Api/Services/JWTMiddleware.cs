using AvioLine.Api.Helper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AvioLine.Api.Services
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachAccountToContext(context, token);

            await _next(context);
        }

        private bool attachAccountToContext(HttpContext context, string token)
        {
            try
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(ConfigurationApplication.AppSetting["JWT:Secret"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = ConfigurationApplication.AppSetting["JWT:ValidIssuer"],
                    ValidateIssuer = true,
                    ValidAudience = ConfigurationApplication.AppSetting["JWT:ValidAudience"],
                    ValidateAudience = true,

                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
           
                var jwtToken = (JwtSecurityToken)validatedToken;
                foreach (var t in jwtToken.Header)
                {
                    Console.WriteLine(t + "  " + t.GetType() + "HEAADER");

                }
                foreach (var t in jwtToken.Claims)
                {
                    Console.WriteLine(t.Value + "  " + t.Type + "CLAIM");

                }
                Console.WriteLine(jwtToken.RawSignature + "SIGNIN KEY");
                Console.WriteLine(jwtToken.SecurityKey + "SECURITY KEY");

            }
            catch (SecurityTokenException)
            {
                return false;
            }
            return true;
        }
    }
}

    

