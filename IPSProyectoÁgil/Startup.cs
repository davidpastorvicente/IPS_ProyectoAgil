using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPSProyectoÁgil.Startup))]
namespace IPSProyectoÁgil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
