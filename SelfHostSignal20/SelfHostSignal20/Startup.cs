using Microsoft.AspNet.SignalR;
using Owin;
using System.IO;
using System.Reflection;

namespace SelfHostSignalR20
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Turn cross domain on 
            var config = new HubConfiguration { EnableCrossDomain = true };
            // This will map out to http://localhost:9999/signalr 
            app.MapHubs(config);
            string exeFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string webFolder = Path.Combine(exeFolder, "Web");
            app.UseStaticFiles(webFolder);
        }
    }
}
