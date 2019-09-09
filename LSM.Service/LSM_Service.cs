using LSM.Engine.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LSM.Service
{
    partial class LSM_Service : ServiceBase
    {
        ServerManager server = null;
        public LSM_Service()
        {
            InitializeComponent();
            // initiate the server manager library
            server = new ServerManager();
        }

        protected override void OnStart(string[] args)
        {
            if (server != null)
            {
                server.Start();
            }
        }

        protected override void OnStop()
        {
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
