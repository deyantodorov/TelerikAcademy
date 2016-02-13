using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HW6.PingPongWithSignalR.Startup))]
namespace HW6.PingPongWithSignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
