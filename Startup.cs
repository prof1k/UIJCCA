using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIJCCA.web.Startup))]
//[assembly: OwinStartup("Test",typeof(UIJCCA.web.Startup))]
namespace UIJCCA.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
