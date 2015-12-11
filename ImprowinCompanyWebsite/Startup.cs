using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImprowinCompanyWebsite.Startup))]
namespace ImprowinCompanyWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
