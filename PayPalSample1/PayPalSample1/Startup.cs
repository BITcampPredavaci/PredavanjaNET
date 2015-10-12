using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayPalSample1.Startup))]
namespace PayPalSample1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
