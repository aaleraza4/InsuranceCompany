using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.UserExtension
{
    public class InsuranceClaimsPrincipleFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public InsuranceClaimsPrincipleFactory(UserManager<ApplicationUser> userManager,IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            
        }


        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var id = await base.GenerateClaimsAsync(user);
            var _roles = await UserManager.GetRolesAsync(user);
            var userRole = _roles != null && _roles.Count > 0 ? _roles.FirstOrDefault() : string.Empty;
            long studentid = 0;
            int tutorId = 0;
            int profileStatus = 1;
            string Reason = "";
           
            id.AddClaim(new Claim("UserRole", userRole));
            id.AddClaim(new Claim("UserId", user.Id.ToString()));
            id.AddClaim(new Claim("StudentId", studentid.ToString()));
            id.AddClaim(new Claim("TutorId", tutorId.ToString()));
            id.AddClaim(new Claim("FirstName", user.FirstName));
            id.AddClaim(new Claim("LastName", user.LastName));
            id.AddClaim(new Claim("ProfileStatus", profileStatus.ToString()));
            id.AddClaim(new Claim("Reason", Reason));
            id.AddClaim(new Claim("Email", user.Email));
            return id;
        }
    }
}
