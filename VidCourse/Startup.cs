using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidCourse.Startup))]
namespace VidCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
