using Papasi.Models;

namespace Papasi.Services;

public interface IMarketService
{
    string? GetCoinsURL();

    Task<List<Coins>?> GetCoinsListAsync();
}