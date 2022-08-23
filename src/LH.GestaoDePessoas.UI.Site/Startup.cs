using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LH.GestaoDePessoas.UI.Site.Startup))]
namespace LH.GestaoDePessoas.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
