using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bysj.Startup))]
namespace bysj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
