using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SDKIntroduction.Startup))]
namespace SDKIntroduction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
