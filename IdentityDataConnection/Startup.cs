using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityDataConnection.Startup))]
namespace IdentityDataConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
