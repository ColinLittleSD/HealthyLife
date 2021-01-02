using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthyLife.WebMVC.Startup))]
namespace HealthyLife.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
