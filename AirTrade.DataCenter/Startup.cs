using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirTrade.DataCenter.Startup))]
namespace AirTrade.DataCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
