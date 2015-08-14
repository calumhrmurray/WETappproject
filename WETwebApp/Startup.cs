using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WETwebApp.Startup))]
namespace WETwebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
