using Microsoft.AspNetCore.Components.Authorization;

namespace Papasi.Services;

public class UserInfoService : IUserInfoService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserInfoService(AuthenticationStateProvider authenticationStateProvider) =>
        _authenticationStateProvider = authenticationStateProvider ??
                                       throw new ArgumentNullException(nameof(authenticationStateProvider));

    public async Task<string?> GetUserIdAsync()
    {
        var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        return authenticationState.User.Identity?.Name;
    }
}