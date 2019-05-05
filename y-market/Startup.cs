using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(y_market.Startup))]
namespace y_market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
