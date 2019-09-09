using LSM.Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerManager server = new ServerManager();
            server.startServer();

            Console.ReadKey(true);
        }
    }
}
