using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Liczniki.Startup))]
namespace Liczniki
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
