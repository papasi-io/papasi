using Papasi.Entities;

namespace Papasi.Services;

public interface ITokenFactoryService
{
    Task<string> CreateJwtTokensAsync(ApplicationUser user);
}