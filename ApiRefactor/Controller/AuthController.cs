using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiRefactor.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            var claims = new[]   { new Claim("scope", "write")  };

            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(                    
                        "ThisIsSecretKeyForCodingAssessmentOnRefactoringWebapi"));

            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.UtcNow.AddHours(1),
                                signingCredentials: credential);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
