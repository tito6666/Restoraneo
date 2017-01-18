using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restoraneo.Startup))]
namespace Restoraneo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
