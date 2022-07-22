using Microsoft.AspNetCore.Http;
using SouthWestContractors.Application.Contracts;
using System;
using System.Security.Claims;

namespace SouthWestContractors.API.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        //public LoggedInUserService(HttpContextAccessor httpContextAccessor)
        //{
        //        UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //}

        //public string UserId { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLoginUserName()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            //return _httpContextAccessor.HttpContext.User.Identity.Name;
            return userId;
        }
    }
}
