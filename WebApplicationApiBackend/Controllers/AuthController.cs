using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationApiBackend.Entities;
using WebApplicationApiBackend.Entities.models;

namespace WebApplicationApiBackend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new();
        public static string userDafault = "Daniel";
        public static string passwordDafault = "123";

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto userRequest)
        {
            //create hash
            var hashPassword = new PasswordHasher<User>()
                .HashPassword(user, userRequest.Password);
            //add hash and name to the user
            user.UserName = userRequest.UserName;
            user.PasswordHash = hashPassword;
            //send request user 
            return Ok(user);
        }
        [HttpPost("login")]
        public ActionResult<string> Login(UserDto userDto) {
            var tojenUser = new RequestToken();
            tojenUser.Token = "";
            tojenUser.Respuesta = false;
            user.UserName = userDafault;
            user.PasswordHash = new PasswordHasher<User>()
                .HashPassword(user, passwordDafault);
            //validate user
            if (user.UserName != userDto.UserName)
            {
                return Ok(tojenUser);
            }
            //validate credentials
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password)== PasswordVerificationResult.Failed){
                return Ok(tojenUser);
            }

            tojenUser.Token = CreateToken(user);
            tojenUser.Respuesta = true;
            return Ok(tojenUser);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            //var key = claims.First();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
            //CREATE CREDENTIAL
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            //create toeken and configuration 
            var isuerPrueba = configuration.GetValue<string>("AppSetting:Issuer");
            var audiencePrueba = configuration.GetValue<string>("AppSetting:Audience");
            var token = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSetting:Issuer"),
                audience: configuration.GetValue<string>("AppSetting:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [Authorize]
        [HttpGet]
        public IActionResult AuthenticationPoint()
        {
            return Ok("good authenticate");
        }
    }
}
