using AidAction.Domain.DomainModels.Auth;
using AidAction.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly JWT _jwt;
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IOptions<JWT> jwt, IAuthRepository authService,IConfiguration configuration)
        {
            _jwt = jwt.Value;
            _authRepository = authService;
           this._configuration = configuration;
        }

        public async Task<AuthModel> AuthenticateAsync(DBResult dBResult)
        {
            var authModel = new AuthModel();
            var jwtSecurityToken = await CreateJwtToken(dBResult.data[0]);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = dBResult.data[0].Email;
            authModel.UserType = dBResult.data[0].UserType;
            authModel.Username = dBResult.data[0].Username;
            authModel.UserId = dBResult.data[0].UserId;
            authModel.FullName = dBResult.data[0].FullName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            return authModel;
        }

        public async Task<DBResult> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _authRepository.UserLoginAsync(model);
            var log0 =Newtonsoft.Json.JsonConvert.DeserializeObject<DBResult>(user.ToString());
            List<DBResult> Log = new List<DBResult>();

            Log.Add(log0);

            if (int.Parse(Log[0].rv) < 1)
            {
                return Log[0];
            }

            var jwtSecurityToken = await CreateJwtToken(Log[0].data[0]);
            //var rolesList = await _authRepository.GetRolesAsync(Log.UserId);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.UserType = Log[0].data[0].UserType;
            authModel.Email = Log[0].data[0].Email;
            authModel.Username = Log[0].data[0].Username;
            authModel.UserId = Log[0].data[0].UserId;
            authModel.FullName = Log[0].data[0].FullName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;

            Log[0].data.Clear();
            Log[0].data.Add(authModel);
          
            return Log[0];
        }


        private async Task<SecurityToken> CreateJwtToken(AuthModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]); // _appSettings.Secret
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim("UserName", user.Username),
                   new Claim("Email", user.Email),
                   new Claim("UserID", user.UserId.ToString(), null),
                   new Claim("UserType", user.UserType, null),
                   new Claim("FullName", user.FullName, null)
               }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();
            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
           
            return true;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}
