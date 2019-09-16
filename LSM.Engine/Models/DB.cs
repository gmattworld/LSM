using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSM.Engine.Models
{
    public static class DB
    {

        public static DatabaseConfig database { get; set; }
        public static AppConfig app { get; set; }
        public static PerformanceConfig performance { get; set; }

        public static ServiceState serviceState { get; set; }
    }
}
