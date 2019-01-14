using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCalisan.Startup))]
namespace MvcCalisan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
