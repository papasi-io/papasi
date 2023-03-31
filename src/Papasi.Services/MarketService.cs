using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Papasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papasi.Services
{
	public class MarketService : IMarketService
	{
		private readonly IOptions<CoinsURL> _coinsURLOptions;
		private readonly IOptions<ChainsInfoURL> _chainsInfoURLOptions;

		public MarketService(IOptions<CoinsURL> coinsURLOptions, IOptions<ChainsInfoURL> chainsInfoURLOptions)
		{
			_coinsURLOptions = coinsURLOptions ?? throw new ArgumentNullException(nameof(coinsURLOptions));
			_chainsInfoURLOptions = chainsInfoURLOptions ?? throw new ArgumentNullException(nameof(coinsURLOptions));
		}

		public string? GetCoinsURL()
		{
			return _coinsURLOptions.Value.Url ??
						throw new InvalidOperationException("Coins Url is null");
		}
		public async Task<List<Coin>?> GetCoinsListAsync()
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromSeconds(3);

				var _coinsListJson = await httpClient.GetStringAsync(GetCoinsURL());

				List<Coin>? _coins = JsonConvert.DeserializeObject<List<Coin>>(_coinsListJson);
				if (_coins != null)
				{
					foreach (var item in _coins)
					{
						var _chainInfoJson = await httpClient.GetStringAsync($"{GetChainsInfoURL()}{item.Symbol}.json");
						ChainInfo? chainInfo = JsonConvert.DeserializeObject<ChainInfo>(_chainInfoJson);
						if (chainInfo != null)
						{
							item.ChainsInfo = chainInfo;
						}
					}
				}

				return _coins;
			}
		}

		public string? GetChainsInfoURL()
		{
			return _chainsInfoURLOptions.Value.Url ??
						throw new InvalidOperationException("ChainsInfo Url is null");
		}


	}
}
