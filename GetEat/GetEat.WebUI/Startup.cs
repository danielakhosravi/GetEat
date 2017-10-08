using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetEat.WebUI.Startup))]
namespace GetEat.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
