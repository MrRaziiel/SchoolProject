using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Finanças.Startup))]
namespace Finanças
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
