using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CmsApplication.Startup))]
namespace CmsApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
