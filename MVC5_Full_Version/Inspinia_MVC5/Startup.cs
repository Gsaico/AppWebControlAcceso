using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inspinia_MVC5.Startup))]
namespace Inspinia_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
