namespace Papasi.Services;

public interface IUserInfoService
{
    Task<string?> GetUserIdAsync();
}