using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(JokeSystem.Web.Startup))]

namespace JokeSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
