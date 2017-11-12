using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kursach3.Startup))]
namespace Kursach3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
