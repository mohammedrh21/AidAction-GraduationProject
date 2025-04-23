using AidAction.Domain.DomainModels.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using static Dapper.SqlMapper;

namespace AidAction.Web.AuthProvider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private static AuthenticationState _AuthState;
        public string? token { get; set; }
        public string? userType { get; set; }
        public string? FullName { get; set; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
                }
                var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

                var _user = new ClaimsPrincipal(identity);

                // Wait for the component to render before doing JavaScript interop
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
                return await Task.FromResult(new AuthenticationState(_user));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return _AuthState;


        }

        public void SetUserAsync(string token, string userType, string fullName)
        {
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            identity.AddClaim(new Claim(ClaimTypes.Role, userType));

            var _user = new ClaimsPrincipal(new ClaimsIdentity());
            _user = new ClaimsPrincipal(identity);

            // Notify the Blazor app that the authentication state has changed
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
        }

        public async Task<AuthModel> GetUserAsync()
        {
            try
            {
                var authState = await GetAuthenticationStateAsync();
                var user = authState.User;

                // Check if the user is authenticated
                if (user.Identity is { IsAuthenticated: true })
                {
                    var userType = user.Claims.FirstOrDefault(x => x.Type.Equals("UserType"))?.Value;
                    var userName = user.Claims.FirstOrDefault(x => x.Type.Equals("UserName"))?.Value;
                    var userId = user.Claims.FirstOrDefault(x => x.Type.Equals("UserId"))?.Value;
                    var fullName = user.Claims.FirstOrDefault(x => x.Type.Equals("FullName"))?.Value;

                    return new AuthModel
                    {
                        UserType = userType,
                        UserId = int.Parse(userId),
                        FullName = fullName,
                        Username = userName,
                        IsAuthenticated = true
                    };
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return new AuthModel();
        }

        public async Task LogoutAsync()
        {
            var authState = await GetAuthenticationStateAsync();
            var _user = new ClaimsPrincipal(new ClaimsIdentity());

            authState = new AuthenticationState(_user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string token)
        {
            var payload = token.Split('.')[1];
            var jsonBytes = Convert.FromBase64String(Base64UrlDecode(payload));
            var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private string Base64UrlDecode(string input)
        {
            input = input.Replace('-', '+').Replace('_', '/');
            switch (input.Length % 4)
            {
                case 2: input += "=="; break;
                case 3: input += "="; break;
            }
            return input;
        }
    }
}
