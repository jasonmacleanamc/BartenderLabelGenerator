using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace LabelsPollingService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            if (Environment.UserInteractive)
            {
                LabelPollingService service = new LabelPollingService();
                service.TestStartupAndStop();
            }
            else
            {
#endif
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new LabelPollingService() 
			    };
                ServiceBase.Run(ServicesToRun);
#if DEBUG
            }
#endif
        }
    }
}

      
