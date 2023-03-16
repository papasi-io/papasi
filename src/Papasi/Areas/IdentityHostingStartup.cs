
using Papasi.Areas.Cabin;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace Papasi.Areas.Cabin;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ConfigureServices((context, services) => { });
    }
}