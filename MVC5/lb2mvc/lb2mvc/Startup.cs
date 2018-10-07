using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lb2mvc.Startup))]
namespace lb2mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
