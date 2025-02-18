using AidAction.Domain.DomainModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AidAction.Services.JwtMiddleware
{
    public interface IUserProvider
    {
        string? GetUserId();
        List<string>? GetUserRoles();
        string? GetUserRolesCommaSeparated();
        string? GetUserName();
        string? GetUserEmail();
        string? GetUserPhoneNumber();
        string? GetClientId();
        AuthModel? UserInfo();
    }
}

public class Roles
{
    public string? Role { get; set; }
}