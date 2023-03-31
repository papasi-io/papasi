using Microsoft.AspNetCore.Components;
using NuGet.Packaging;
using Papasi.Models;
using Papasi.Services;
using System.Net;
using System.Security.Policy;
using static System.Net.WebRequestMethods;

namespace Papasi.Pages.Market
{
	public partial class Providers
	{
		[Inject] public IProvidersService ProvidersService { set; get; } = default!;



		private IEnumerable<Models.Provider> providers { get; set; } = new List<Models.Provider>();

		protected override async Task OnInitializedAsync()
		{

			providers = await ProvidersService.GetProvidersListAsync();

		}
	}
}
