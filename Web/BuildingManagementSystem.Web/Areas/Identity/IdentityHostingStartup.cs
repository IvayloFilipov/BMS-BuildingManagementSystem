using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BuildingManagementSystem.Web.Areas.Identity.IdentityHostingStartup))]

namespace BuildingManagementSystem.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}
