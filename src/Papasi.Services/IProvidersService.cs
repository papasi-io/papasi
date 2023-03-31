using Papasi.Models;

namespace Papasi.Services;

public interface IProvidersService
{
	string? GetAllowURL();
	string? GetDenyURL();

	Task<List<Provider>?> GetProvidersListAsync();
}