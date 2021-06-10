using FriendsAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAppAPI.Repository
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public IdentityRepository(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<AppUser> GetUser(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            return user;
        }

        public async Task<SignInResult> Login(AppUser user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user, 
                password, false, false);
            return result;

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(AppUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
    }
}
