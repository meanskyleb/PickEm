using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PickEm.WebMVC.Startup))]
namespace PickEm.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
