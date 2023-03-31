using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Papasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Papasi.Services
{
	public class ProvidersService : IProvidersService
	{
		private readonly IOptions<ProvidersURL> _providersURLOptions;

		public ProvidersService(IOptions<ProvidersURL> providersURLOptions)
		{
			_providersURLOptions = providersURLOptions ?? throw new ArgumentNullException(nameof(providersURLOptions));

		}
		public string? GetAllowURL()
		{
			return _providersURLOptions.Value.AllowUrl ??
						throw new InvalidOperationException("Allow Url is null");
		}

		public string? GetDenyURL()
		{
			return _providersURLOptions.Value.DenyUrl ??
						throw new InvalidOperationException("Deny Url is null");
		}

		public async Task<List<Provider>?> GetProvidersListAsync()
		{
			using (var httpClient = new HttpClient())
			{
				var json = await httpClient.GetStringAsync(GetAllowURL());

				List<Provider>? _providers = JsonConvert.DeserializeObject<List<Provider>>(json);

				if (_providers != null)
				{
					foreach (var item in _providers)
					{
						if (item.url != null)
						{
							item.isOnline = await Ping(item.url);
						}

					}
				}
				return _providers;
			}

		}

		public async Task<bool> Ping(string url)
		{
			try
			{
				using (HttpClient _httpClient = new HttpClient())
				{
					_httpClient.Timeout = TimeSpan.FromSeconds(3);
					var responseMessage = await _httpClient.GetAsync(new Uri(url));
					return responseMessage.IsSuccessStatusCode;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}


	}
}
