using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Vineeth.Models;

namespace Vineeth.Helpers
{
    public class Userclamis : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public Userclamis(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity= await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserfirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            return identity;


        }
    }
}






