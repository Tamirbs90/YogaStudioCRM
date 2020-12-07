using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using YogaStudio.Login;
using YogaStudio.Models;

namespace YogaStudio.Services
{
    public abstract class LoginService 
    {
        protected readonly UserManager<User> usersManager;
        protected readonly SignInManager<User> signInManager;
        protected readonly AppSettings appSettings;
        protected IMapper mapper;

        public LoginService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            this.usersManager = userManager;
            this.signInManager = signInManager;
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
        }

        public virtual async Task<LoginSuccessModel> Login(LoginDto loginRequest)
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
                Token = CreateToken(user)
            };
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public virtual async Task<object> Register(RegisterDto registerRequest)
        {
            var newUser = mapper.Map<RegisterDto, User>(registerRequest);
            var result = await usersManager.CreateAsync(newUser, registerRequest.Password);
            if (!result.Succeeded)
                return result.Errors.ToList();
            return new LoginSuccessModel
            {
                DisplayName = newUser.FirstName,
                Token = CreateToken(newUser)
            };
        }

        public virtual async Task<User> CheckIfUserExists(string username)
        {
            return await usersManager.FindByNameAsync(username);
        }

        public abstract string CreateToken(User user);
    }
}
