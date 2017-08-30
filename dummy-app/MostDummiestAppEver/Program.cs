using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ThreadContext.Properties["hostname"] = HostName;

            Console.WriteLine("Press Q to quit");
            Console.WriteLine("Press S to info");
            Console.WriteLine("Press E to fail randomly");
            Console.WriteLine("Press B to bulk 1000 fail with 7 days period randomly");
            Console.WriteLine("Press C to clear screen");
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Q: return;
                    case ConsoleKey.S: SendEvent(DateTime.UtcNow); break;
                    case ConsoleKey.E: FailRandom(DateTime.UtcNow); break;
                    case ConsoleKey.C: Console.Clear(); break;
                    case ConsoleKey.B: BulkFailRandomly(1000); break;
                }
            }
        }

        private static int _sendEventCount = 0;
        private static void SendEvent(DateTime mockTime)
        {
            ThreadContext.Properties["exceptionType"] = "-";
            ThreadContext.Properties["mockTime"] = mockTime.ToString("o");
            Log.Info("UDP event sent: " + (++_sendEventCount).ToString("D3"));
        }

        private static readonly Type[] ExceptionTypes = new[]
        {
            typeof(ArgumentNullException), typeof(InvalidOperationException), typeof(NotImplementedException),
            typeof(NotSupportedException)
        };

        private static void FailRandom(DateTime mockTime)
        {
            try
            {
                var exceptionType = ExceptionTypes[new Random().Next(0, ExceptionTypes.Length)];
                throw (Exception)Activator.CreateInstance(exceptionType);
            }
            catch (Exception ex)
            {
                ThreadContext.Properties["exceptionType"] = ex.GetType().FullName;
                ThreadContext.Properties["mockTime"] = mockTime.ToString("o");
                Log.Error("Unhandled exception", ex);
            }
        }

        private static void BulkFailRandomly(int count)
        {
            var today = DateTime.UtcNow.Date;
            var span = today.AddDays(7).AddMilliseconds(-1).Ticks - today.Ticks;

            Console.WriteLine($"Starting bulking {count} exceptions");
            for (var i = 0; i < count; i++)
            {
                var pick = new Random(i).NextLong(0, span, true);
                var date = today.AddTicks(pick);
                FailRandom(date);
            }
            Console.WriteLine("Done...");
        }

        private static string HostName => Dns.GetHostName();
    }
}
