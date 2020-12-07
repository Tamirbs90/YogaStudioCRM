using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YogaStudio.Services;
using YogaStudio.Login;

namespace YogaStudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;

        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginSuccessModel>> Login(LoginDto loginDto)
        {
            var result = await loginService.Login(loginDto);
            if (result == null)
                return BadRequest("Wrong Username or passowrd");
            return result;
        }

        [HttpPost("register")]

        public async Task<ActionResult<object>> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Wrong input");
            }
            
            var userExists = await loginService.CheckIfUserExists(registerDto.UserName);
            if (userExists!=null)
                return BadRequest("Username alreeady exist");
            var result = await loginService.Register(registerDto);
            if (result.GetType() == typeof(LoginSuccessModel))
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await loginService.Logout();
            return Ok();
        }


    }
}
