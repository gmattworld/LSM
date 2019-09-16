using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSM.Engine.Models
{
    public class AppConfig
    {
        public string ServerID { get; set; }
        public int TotalBatchSize { get; set; }
        public bool EnableDebug { get; set; }
        public bool AutoStart_TAlert { get; set; }
        public bool AutoStart_CAlert { get; set; }
        public bool AutoStart_AutoSync { get; set; }
        public bool AutoStart_SMSBanking { get; set; }
        public bool AutoStart_ServiceCharge { get; set; }
        public bool AutoStart_Anniversary { get; set; }
    }
}
