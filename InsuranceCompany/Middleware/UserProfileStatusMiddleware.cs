using Common.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Middleware
{
    public class UserProfileStatusMiddleware
    {
        private readonly RequestDelegate _next;
        public UserProfileStatusMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, UserSessionProfileService _userSessionProfileService)
        {

            // Redirect to login if user is not authenticated. This instruction is neccessary for JS async calls, otherwise everycall will return unauthorized without explaining why
            //var userProfile = _userSessionProfileService.GetUserModel();
            //if (userProfile != null && userProfile.TutorId > 0 && userProfile.ProfileStatus == ENUM.TutorStatusEnum.Rejected && (httpContext?.Request?.Path) != "/Account/ProfileRejected")
            //{
            //    httpContext.Response.Redirect("/Account/ProfileRejected");
            //}
            // Move forward into the pipeline
            await _next(httpContext);
        }
    }
}
