using Microsoft.AspNetCore.Identity;
using Registerloginpage.Models;
using System.Threading.Tasks;

namespace Registerloginpage.Repository
{
    public interface IAccountrepository
    {
        Task<IdentityResult> CreateUser(Signup userModel);
        Task<SignInResult> passwordlogin(Login login);
        Task Signout();
    }
}