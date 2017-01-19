using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mercurii.Startup))]
namespace Mercurii
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
