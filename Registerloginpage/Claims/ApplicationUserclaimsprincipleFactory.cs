using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Registerloginpage.Models;
using System.Security.Claims;

namespace Registerloginpage.Claims
{
    public class ApplicationUserClaimsPrincipleFactory:UserClaimsPrincipalFactory<Applicationuser,IdentityRole>
    {
        public ApplicationUserClaimsPrincipleFactory(UserManager<Applicationuser> userManager,RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options):base(userManager,roleManager,options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Applicationuser user)
        {
            var identity=  await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", user.FirstName?? " ")); 
            identity.AddClaim(new Claim("UserLastName", user.LastName?? " "));
            return identity;


        }

    }
}
