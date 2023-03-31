using Papasi.Models;

namespace Papasi.Services;

public interface IMarketService
{
	string? GetCoinsURL();
	string? GetChainsInfoURL();

	Task<List<Coin>?> GetCoinsListAsync();
}