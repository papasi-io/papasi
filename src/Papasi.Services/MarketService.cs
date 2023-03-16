using Microsoft.Extensions.Options;
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

        public MarketService(IOptions<CoinsURL> coinsURLOptions)
        {
            _coinsURLOptions = coinsURLOptions ?? throw new ArgumentNullException(nameof(coinsURLOptions));

        }

        public string? GetCoinsURL()
        {
            return _coinsURLOptions.Value.Url ??
                        throw new InvalidOperationException("Coins Url is null");
        }
        public Task<List<Coins>?> GetCoinsListAsync()
        {
            throw new NotImplementedException();
        }


    }
}
