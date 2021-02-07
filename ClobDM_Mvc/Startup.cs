using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClobDM_Mvc.Startup))]
namespace ClobDM_Mvc
{
    public partial class Startup
    {
        //12323123,4545
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
