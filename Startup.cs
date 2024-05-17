using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IzimpisiApplicationsOffice.Startup))]
namespace IzimpisiApplicationsOffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
