using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S08D05_MinniApp.Startup))]
namespace S08D05_MinniApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
