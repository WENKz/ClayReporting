using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClayReporting.UI.Startup))]
namespace ClayReporting.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
