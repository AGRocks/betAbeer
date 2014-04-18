using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BetABeer.Startup))]

namespace BetABeer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuthentication(app);
            this.ConfigureSignalR(app);
        }
    }
}