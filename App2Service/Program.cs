using App2Service.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace App2Service
{
    static class Program
    {
        public static List<ServiceSet> ConfiguredServices { get; private set; }
        public static Thread StartThread { get; internal set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            _ConfigureTrace();

            try {
                Trace.WriteLine("App2Service");
                Trace.WriteLine("Configuring...");
                ConfiguredServices = new List<ServiceSet>();
                ConfiguredServices = ServiceConfigs.Load();
            }
            catch(Exception exp)
            {
                Trace.WriteLine("Error on load:");
                Trace.WriteLine(exp);
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service()
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void _ConfigureTrace()
        {
            string logFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Services.log");

            if(File.Exists(logFile))
            {
                File.Delete(logFile);
            }

            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
        }
    }
}
