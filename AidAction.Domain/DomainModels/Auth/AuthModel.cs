using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels.Auth
{
    public class DBResult
    {
        public string? rv { set; get; }
        public string? Msg { set; get; }
        public List<AuthModel>? data { set; get; }
    }

    public class DBResultWithout
    {
        public int? rv { set; get; }
        public string? Msg { set; get; }
    }
    public class AuthModel
    {
        public int UserId { set; get; }
        public string? UserType { get; set; }
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
        public string? FullName { get; set; }
        public DateTime? ExpiresOn { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
