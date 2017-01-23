using Microsoft.Owin;
using Owin;
using System.Threading;
using ClayReporting.Process;
[assembly: OwinStartupAttribute(typeof(ClayReporting.UI.Startup))]
namespace ClayReporting.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ThreadImport objetImportation = new ThreadImport();
            Thread workerThread = new Thread(objetImportation.Import);

            workerThread.Start();
        }
    }
}
