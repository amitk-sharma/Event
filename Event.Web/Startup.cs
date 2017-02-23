using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Event.Web.Startup))]
namespace Event.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
