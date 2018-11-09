using System;
using System.Timers;

namespace PingMonitor.Service
{
    public class PingMonitorJob
    {
        readonly Timer _timer;
        public PingMonitorJob()
        {
            _timer = new Timer(500) { AutoReset = true };
            _timer.Elapsed += OnTimer;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            var pingResult = ping.Send("www.seznam.cz", 25);
            Console.WriteLine(pingResult.Status.ToString() + " - " + pingResult.RoundtripTime);
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
