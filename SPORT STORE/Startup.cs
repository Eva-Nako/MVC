using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPORT_STORE.Startup))]
namespace SPORT_STORE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
