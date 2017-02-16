using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppTours.Startup))]
namespace WebAppTours
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
