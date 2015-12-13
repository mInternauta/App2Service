using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace App2Service.Logic
{
    public class AppService
    {
        private ServiceSet mySet;
        private Process proc;

        public string Name
        {
            get
            {
                return mySet.Name;
            }
        }

        public AppService(ServiceSet mySet)
        {
            this.mySet = mySet;
        }

        public void Stop()
        {
            if(mySet.StopWithService)
            {
                if(proc != null && proc.HasExited == false)
                {
                    // Try to send the Close Message
                    Win32Utils.Quit(proc.Handle);

                    // Wait
                    proc.WaitForExit(1000);
                    
                    // If not quit 
                    if(proc.HasExited == false)
                    {
                        proc.Kill();
                    }
                }
            }
        }

        public void Start()
        {
            Trace.WriteLine("Starting", mySet.Name);

            this.proc = createProcess();
            
            if (mySet.RedirectStandardOutput)
            {
                proc.OutputDataReceived += Proc_OutputDataReceived;
            }
            
            proc.Start();

            Trace.WriteLine("Started", mySet.Name);
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine("[STDOUT] " + e.Data, mySet.Name);
        }

        private Process createProcess()
        {
            Process proc = new Process();
            ProcessStartInfo start = new ProcessStartInfo();

            if (string.IsNullOrEmpty(mySet.Parameters) == false)
            {
                start.Arguments = mySet.Parameters;
            }

            start.FileName = mySet.Executable;

            if (mySet.RedirectStandardOutput)
            {
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
            }

            proc.StartInfo = start;
            return proc;
        }
    }
}
