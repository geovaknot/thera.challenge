using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Thera.Talent.Management.Web.App_Start.Startup))]

namespace Thera.Talent.Management.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
