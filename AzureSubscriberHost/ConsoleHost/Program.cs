using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleHost
{
    class Program
    {
        static Timer timer;
        static Container container;
        static void Main(string[] args)
        {
            timer = new Timer(new TimeSpan(0, 0, 30).TotalMilliseconds);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            Console.WriteLine("Host starting...");
            container = new Container();
            timer.Start();

            Console.WriteLine("Host started. Press any key to exit...");
            Console.ReadKey();

            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            container.StopAllServices();
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // check for new dlls and start those services
            Console.WriteLine("Checking for new services");
            container.CheckForNewServices();
        }
    }
}
