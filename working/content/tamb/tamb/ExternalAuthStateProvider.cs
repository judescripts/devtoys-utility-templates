using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace TAMB
{
    public class ExternalAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
            Task.FromResult(new AuthenticationState(_currentUser));

        public Task<AuthenticationState> LogInAsync()
        {
            var loginTask = LogInAsyncCore();
            NotifyAuthenticationStateChanged(loginTask);

            return loginTask;

            async Task<AuthenticationState> LogInAsyncCore()
            {
                var user = await LoginWithExternalProviderAsync();
                _currentUser = user;

                return new AuthenticationState(_currentUser);
            }
        }

        private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
        {
            /*
                Provide OpenID/MSAL code to authenticate the user. See your identity
                provider's documentation for details.

                Return a new ClaimsPrincipal based on a new ClaimsIdentity.
            */
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new (ClaimTypes.Name, "Jennifer Smith"),
                new (ClaimTypes.Email, "jennifer@smith.com"),
                new (ClaimTypes.Role, "Administrator")
            }, "CustomAuth"));

            return Task.FromResult(authenticatedUser);
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }

    public class AuthenticatedUser
    {
        public ClaimsPrincipal Principal { get; set; } = new();
    }
}
