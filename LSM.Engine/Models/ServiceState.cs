using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSM.Engine.Models
{
    public class ServiceState
    {
        public bool TAlertModule { get; set; }
        public bool FlexAlertModule { get; set; }
        public bool AlertArchivingService { get; set; }
        public bool AutoSyncModule { get; set; }
        public bool SMSBankingModule { get; set; }
        public bool BirthdayNotificationModule { get; set; }
        public bool ServiceChargePostingModule { get; set; }
    }
}
