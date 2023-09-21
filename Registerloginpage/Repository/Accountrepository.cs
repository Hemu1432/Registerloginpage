using Microsoft.AspNetCore.Identity;
using Registerloginpage.Models;

namespace Registerloginpage.Repository
{
    public class Accountrepository : IAccountrepository
    {
        private readonly UserManager<Applicationuser> _userManager;
        private readonly SignInManager<Applicationuser> _signInManager;

        public Accountrepository(UserManager<Applicationuser> userManager,SignInManager<Applicationuser> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUser(Signup userModel)
        {
            var user = new Applicationuser() { FirstName=userModel.FirstName,LastName=userModel.LastName,UserName = userModel.Email, Email = userModel.Email,  };
            var result=await _userManager.CreateAsync(user,userModel.Password);
            return result;
        }
        public async Task<SignInResult> passwordlogin(Login login)
        {
           var result=await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
            return result;
        }
        public async Task Signout()
        {
            await _signInManager.SignOutAsync();
        }
        //public async Task<IdentityResult> ChangePassword(ChangePassword changePassword,Login login)
        //{
        //    var username=login.Email;
        //    await _userManager.ChangePasswordAsync(username,changePassword.currentpassword,changePassword.Newpassword)
        //}
    }
}
