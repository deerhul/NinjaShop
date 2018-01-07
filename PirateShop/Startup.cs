using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PirateShop.Startup))]
namespace PirateShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
