using AidAction.Domain.DomainModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AidAction.Services.JwtMiddleware
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;
        private readonly IConfiguration _configuration;

        public UserProvider(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration;
        }

        public string? GetUserId()
        {
            var client_id = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "client_id")?.Value;
            if (client_id == _configuration["Users:ClientId"])
                return _configuration["Users:ExternalUserId"];
            return _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public string? GetUserName()
        {
            return _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "FullName")?.Value;
        }
        public string? GetUserEmail()
        {
            return _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "Email")?.Value;
        }
        public string? GetUserPhoneNumber()
        {
            return _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "PhoneNumber")?.Value;
        }

        public List<string> GetUserRoles()
        {
            List<string> roles = new List<string>();
            var role = _context.HttpContext.User.Claims.Where(i => i.Type == ClaimTypes.Role)?.ToList();
            foreach (var item in role)
            {
                roles.Add(item.Value);
            }
            return roles;
        }
        public string GetUserRolesCommaSeparated()
        {
            var rolesList = GetUserRoles();
            var roles = string.Join(",", rolesList);
            return roles;
        }

        public string? GetClientId()
        {
            return _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "client_id")?.Value;
        }

        public AuthModel? UserInfo()
        {
            var s = new AuthModel();
            s.UserId= int.Parse(_context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "UserID")?.Value);
            return s;
        }
    }
}
