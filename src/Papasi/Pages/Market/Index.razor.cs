using Microsoft.AspNetCore.Components;
using Papasi.Services;

namespace Papasi.Pages.Market
{
    public partial class Index
    {
        [Inject] public IMarketService MarketService { set; get; } = default!;

    }
}
