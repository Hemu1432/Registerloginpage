using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registerloginpage.Models;
using Registerloginpage.Repository;

namespace Registerloginpage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountrepository _accountrepository;

        public AccountController(IAccountrepository accountrepository)
        {
            _accountrepository = accountrepository;
        }
        [Route("signup")]
        public IActionResult signup()
        {
            return View();
        }
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signup(Signup userModel) { 
        
            if(ModelState.IsValid)
            {
                var result = await _accountrepository.CreateUser(userModel);    
                if(!result.Succeeded)
                {
                    foreach (var errormessage in result.Errors)
                    {
                        ModelState.AddModelError("", errormessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
            }
            return View();
        
        }
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]

        public async Task<IActionResult> Login(Login login, string returnurl)
        {
             if (ModelState.IsValid==false)
            {
                var result = await _accountrepository.passwordlogin(login);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnurl))
                    {
                        return LocalRedirect(returnurl);
                    }
                    return RedirectToAction("Index", "Functionality");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(login);
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountrepository.Signout();
            return RedirectToAction("Index","Home");
            
        }
        //[Route("change-password")]
        //public IActionResult Changepassword(ChangePassword changePassword)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
        //    return View(changePassword);
        //}
    }
}
