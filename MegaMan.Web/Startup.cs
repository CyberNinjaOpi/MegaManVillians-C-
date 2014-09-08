using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MegaMan.Web.Startup))]
namespace MegaMan.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
