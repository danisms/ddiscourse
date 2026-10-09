using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ddiscourse.Data;

/*
* NOTE: Purpose;
* To add the full name into the sign-in cookie, so the sidebar can show it without a database query.
*/

public class AppClaimsPrincipalFactory(
    UserManager<ApplicationUser> users,
    RoleManager<IdentityRole> roles,
    IOptions<IdentityOptions> options)
    : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>(users, roles, options)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("full_name", user.FullName));
        identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
        
        return identity;
    }
}