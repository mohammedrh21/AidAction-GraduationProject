using AidAction.Domain.DomainModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthModel> AuthenticateAsync(DBResult dBResult);
        Task<DBResult> GetTokenAsync(TokenRequestModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
    }
}
