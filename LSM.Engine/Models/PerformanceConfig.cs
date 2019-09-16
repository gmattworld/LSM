using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSM.Engine.Models
{
    public class PerformanceConfig
    {
        public string MaxDBConnection { get; set; }
        public int ConnectionTimeOut { get; set; }
        public int MaxConOps_TAlert { get; set; }
        public int MaxConOps_SC { get; set; }
        public int MaxConOps_AutoSync { get; set; }
        public int MaxConOps_Anniversary { get; set; }
        public int MaxConOps_SMSBanking { get; set; }
        public int MaxConOps_CAlert { get; set; }
    }
}
