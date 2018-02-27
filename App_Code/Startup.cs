using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaServerMonitor.Startup))]
namespace MediaServerMonitor
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }

        // Logic to start our service monitors: 

        // Scan for service's that are in our database - Every 10 minutes. 

        






    }


   

}
