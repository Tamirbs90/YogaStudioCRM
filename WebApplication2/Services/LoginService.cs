using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using YogaStudio.Login;
using YogaStudio.Models;

namespace YogaStudio.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> usersManager;
        private readonly SignInManager<User> signInManager;
        private IMapper mapper;

        /* public LoginService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
         {
             this.usersManager = userManager;
             this.signInManager = signInManager;
             this.mapper = mapper;
         }*/

        public async Task<LoginSuccessModel> Login(LoginDto loginRequest)
        {
            var user = await usersManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
                return null;
            var result = await signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (!result.Succeeded)
                return null;
            return new LoginSuccessModel
            {
                DisplayName = user.FirstName,
                Token = "will be a token"
            };
        }



        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<LoginSuccessModel> Register(RegisterDto registerRequest)
        {
            var userExists = await usersManager.FindByEmailAsync(registerRequest.Email);
            if (userExists != null)
                return null;
            var newUser = mapper.Map<RegisterDto, User>(registerRequest);
            var result = await usersManager.CreateAsync(newUser, registerRequest.Password);
            if (!result.Succeeded)
                return null;
            return new LoginSuccessModel
            {
                DisplayName = newUser.FirstName,
                Token = "this well be a token"
            };
        }
    }
}
