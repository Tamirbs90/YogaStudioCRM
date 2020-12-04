//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using YogaStudio.Services;
//using YogaStudio.Login;

//namespace YogaStudio.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        private readonly ILoginService loginService;

//        public LoginController(ILoginService loginService)
//        {
//            this.loginService = loginService;
//        }

//        [HttpPost("login")]
//        public async Task<ActionResult<LoginSuccessModel>> Login(LoginDto loginDto)
//        {
//            var result = await loginService.Login(loginDto);
//            if (result == null)
//                return BadRequest("Login Failed");
//            return result;
//        }

//        [HttpPost("register")]

//        public async Task<ActionResult<LoginSuccessModel>> Register(RegisterDto registerDto)
//        {
//            var result = await loginService.Register(registerDto);
//            if (result == null)
//                return BadRequest("User already exists");
//            return result;
//        }

//        [HttpGet("logout")]
//        public async Task<ActionResult> Logout()
//        {
//            await loginService.Logout();
//            return Ok();
//        }

            
//    }
//}
