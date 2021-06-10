using FriendsAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAppAPI.Repository
{
    interface IIdentityRepository 
    {
        Task<AppUser> GetUser(string username);
        Task<SignInResult> Login(AppUser user, string password);
        Task<IdentityResult> Register(AppUser user, string password);
        Task Logout();
    }
}
