using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S08D04_MiniApp.Startup))]
namespace S08D04_MiniApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
