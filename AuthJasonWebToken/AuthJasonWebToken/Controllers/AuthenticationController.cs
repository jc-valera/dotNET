using Auth.Core.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthJasonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //public string SecretKey;

        //public AuthenticationController(IConfiguration config)
        //{
        //    SecretKey = config.GetSection("AppSettings").GetSection("SecretKey").ToString();
        //}
        //private readonly string SecretKey;
        //public AuthenticationController(IConfiguration config)
        //{
        //    SecretKey = config.GetSection("AppSettings").GetSection("SecretKey").ToString();
        //}

        public AppSettings AppSettings;

        public AuthenticationController(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("validateAuth")]
        public async Task<IActionResult> ValidateAuth([FromBody] User user)
        {
            if (user.Email == "jcvalera.emp@gmail.com" && user.Password == "123456")
            {
                var keyBytes = Encoding.ASCII.GetBytes(AppSettings.SecretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(
                    new Claim(
                        ClaimTypes.NameIdentifier,
                        user.Email
                    ));

                var tokenDescriptior = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptior);

                var tokenCreated = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreated });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }

        [HttpPost]
        [Route("validateAuth1")]
        public async Task<IActionResult> ValidateAuth1([FromBody] User user)
        {
            AuthResponse authResponse;

            if (user.Email == "jcvalera.emp@gmail.com" && user.Password == "123456")
            {
                var keyBytes = Encoding.ASCII.GetBytes(AppSettings.SecretKey);

                var claims = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    });

                var tokenDescriptior = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptior);

                authResponse = new AuthResponse
                {
                    Token = tokenHandler.WriteToken(tokenConfig),
                    Message = "Token generado correctamente.",
                    Success = true,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                authResponse = new AuthResponse
                {
                    Token = "",
                    Message = "Usuario o Contraseña incorrecta.",
                    Success = false,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            return Ok(authResponse);
        }
    }
}
