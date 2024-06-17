using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectoTecnologiasDaInternet3.Startup))]
namespace ProjectoTecnologiasDaInternet3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
