using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeInEsbjerg.Startup))]
namespace LifeInEsbjerg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
