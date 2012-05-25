using System.ServiceProcess;

namespace Negar
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[] { new NegarSMSSender() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}