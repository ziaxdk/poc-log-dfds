using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace MostDummiestAppEver
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            Console.WriteLine("Press Q to quit and any key to send an UDP event");
            var key = Console.ReadKey(false);
            var i = 0;
            while (key.Key != ConsoleKey.Q)
            {
                Log.Info("UDP event sent: "+ (++i).ToString("D3"));
                key = Console.ReadKey();
            }
        }

    }
}
