using System;

namespace PingMonitor.Service
{
    public class PingMonitorJobConfiguration
    {
        public TimeSpan BatchInterval { get; set; }
        public int BatchSize { get; set; }
        public TimeSpan PingTimeout { get; set; }
        public TimeSpan IntervalBetweenPings { get; set; }
        public string TargetUrl { get; set; }

    }
}
