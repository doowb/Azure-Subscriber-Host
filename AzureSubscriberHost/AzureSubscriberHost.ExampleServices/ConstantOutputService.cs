using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureSubscriberHost.Contracts;
using System.Timers;
using System.ComponentModel.Composition;

namespace AzureSubscriberHost.ExampleServices
{
    [Export(typeof(ISubscriberService))]
    public class ConstantOutputService : ISubscriberService
    {
        Timer timer;
        public ConstantOutputService()
        {
            Console.WriteLine("Initializing Constant Output Service");
            InitTimer();
        }

        protected void InitTimer()
        {
            timer = new Timer(new TimeSpan(0, 0, 5).TotalMilliseconds);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now, "Constant Output Service");
        }

        public void Start()
        {
            if (timer == null)
                InitTimer();
            timer.Start();
        }

        public void Stop()
        {
            if (timer != null)
                timer.Stop();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing Constant Output Service");
            if (timer != null)
                timer.Dispose();
        }
    }
}
