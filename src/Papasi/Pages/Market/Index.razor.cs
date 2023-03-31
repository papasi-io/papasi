using Microsoft.AspNetCore.Components;
using Papasi.Models;
using Papasi.Services;

namespace Papasi.Pages.Market
{
	public partial class Index
	{
		[Inject] public IMarketService MarketService { set; get; } = default!;

		private IEnumerable<Models.Coin> coinsList { get; set; } = new List<Models.Coin>();

		protected override async Task OnInitializedAsync()
		{

			coinsList = await MarketService.GetCoinsListAsync();

		}

	}
}
