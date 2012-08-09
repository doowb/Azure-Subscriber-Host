using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureSubscriberHost.Contracts;
using System.ComponentModel.Composition;
using System.Timers;

namespace AzureSubscriberHost.ExampleServices
{

    [Export(typeof(ISubscriberService))]
    public class RandomOutputService : ISubscriberService
    {
        Timer timer;
        public RandomOutputService()
        {
            Console.WriteLine("Initializing Random Output Service");
            InitTimer();
        }

        protected void InitTimer()
        {
            int seconds = new Random().Next(1, 10);
            timer = new Timer(new TimeSpan(0, 0, seconds).TotalMilliseconds);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            Console.WriteLine("[{0}] {1}", DateTime.Now, "Random Output Service");
            int seconds = new Random().Next(1, 10);
            timer.Interval = new TimeSpan(0, 0, seconds).TotalMilliseconds;
            timer.Enabled = true;
        }

        public void Start()
        {
            if (timer == null)
                InitTimer();
            timer.Start();
        }

        public void Stop()
        {
            if(timer != null)
                timer.Stop();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing Random Output Service");
            if (timer != null)
                timer.Dispose();
        }
    }
}
