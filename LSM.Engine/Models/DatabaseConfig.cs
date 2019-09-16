using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSM.Engine.Models
{
    public class DatabaseConfig
    {
        public string AppRegistry { get; set; }
        public string DBType { get; set; }
        public string ServerName { get; set; }
        public string Port { get; set; }
        public string DBInstance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
