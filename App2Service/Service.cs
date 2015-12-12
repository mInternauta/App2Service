using App2Service.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App2Service
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Program.StartThread = new Thread(new ThreadStart(_StartServices));
            Program.StartThread.IsBackground = true;
            Program.StartThread.Start();
        }

        private void _StartServices()
        {
            Trace.WriteLine("Starting the Services.." + Program.ConfiguredServices.Count);

            foreach (ServiceSet service in Program.ConfiguredServices)
            {
                Trace.WriteLine("[" + service.Name + "] Starting...");

                try
                {
                    if (string.IsNullOrEmpty(service.Parameters))
                    {
                        Process.Start(service.Executable);
                    }
                    else
                    {
                        Process.Start(service.Executable, service.Parameters);
                    }

                    Trace.WriteLine("[" + service.Name + "] Started");
                }
                catch (Exception exp)
                {
                    Trace.WriteLine("[" + service.Name + "] Error when start: ");
                    Trace.WriteLine(exp);
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
