using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(KitundaChurch.Areas.Identity.IdentityHostingStartup))]
namespace KitundaChurch.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}