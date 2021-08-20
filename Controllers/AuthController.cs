using System.Threading.Tasks;
using Character.BLL.Authentication;
using Character.BLL.Dtos.Character;
using Character.BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Resgister (UserRegisterDto userRegisterDto)
        {
            var response = await _authentication.Register(
                                new User{UserName = userRegisterDto.UserName}, 
                                        userRegisterDto.Password);
            if(response.Response)
                return BadRequest(response);
            return Ok(response);

        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Resgister (UserLogInDto userLogInDto)
        {
            var response = await _authentication.Login(userLogInDto.UserName, 
                                        userLogInDto.Password);
            if(response.Response)
                return BadRequest(response);
            return Ok(response);

        }

    }
}