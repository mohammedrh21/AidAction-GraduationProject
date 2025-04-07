using AidAction.Domain.DomainModels;
using AidAction.Domain.DomainModels.Auth;
using AidAction.Domain.Interfaces;
using AidAction.Repository.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Repository.Repositories
{
    public class AuthRepository : GenericRepository, IAuthRepository
    {
        public AuthRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<JObject> UserLoginAsync(TokenRequestModel model)
        {
            return await CommandAsync<JObject>("dbo.UserLogin", model);
        }

        public async Task<JObject> SaveTokenAsync(object o)
        {
            return await CommandAsync<JObject>("dbo.TokenSave", o);
        }

        public async Task<JObject> ChangePasswordAsync(ChangePasswordModel model)
        {
            return await CommandAsync<JObject>("dbo.ChangePassword", model);
        }
        //public async Task<List<string>> GetRolesAsync(int UserId)
        //{
        //    return await CommandAsync<List<string>>("dbo.UserLogin", new { UserId });
        //}

    }
}
