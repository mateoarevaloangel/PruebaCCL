using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApiBackend.Entities;
using WebApplicationApiBackend.Entities.models;

namespace WebApplicationApiBackend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto userRequest)
        {
            //credential valitation
            var hashPassword = new PasswordHasher<User>()
                .HashPassword(user, userRequest.Password);
            user.UserName = userRequest.UserName;
            user.PasswordHash = hashPassword;

            return Ok(user);
        }
    }
}
