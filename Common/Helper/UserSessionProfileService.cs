using DTO.UserProfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class UserSessionProfileService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserSessionProfileService(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
        public UserProfileDto GetUserModel()
        {

            UserProfileDto ob = new UserProfileDto();
            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null && httpContextAccessor.HttpContext.User.Identity != null && httpContextAccessor.HttpContext.User.Claims != null)
            {
                ob.UserId = Convert.ToInt32((httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value) ?? "0");
                ob.StudentId = Convert.ToInt64((httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StudentId")?.Value) ?? "0");
                ob.UserRole = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserRole")?.Value;
                ob.FirstName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "FirstName")?.Value;
                ob.LastName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "LastName")?.Value;
                ob.Email = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;
                return ob;
            }
            return null;
        }

        public bool IsClaimExists(string claimName)
        {

            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null && httpContextAccessor.HttpContext.User.Identity != null && httpContextAccessor.HttpContext.User.Claims != null)
            {
                return httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type == claimName);
            }
            return false;
        }


    }
}
