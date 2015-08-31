using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S15D05_Pics.Startup))]
namespace S15D05_Pics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
