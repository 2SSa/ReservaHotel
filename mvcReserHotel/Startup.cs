using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcReserHotel.Startup))]
namespace mvcReserHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
