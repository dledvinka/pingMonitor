using System;
using System.Collections.Generic;

namespace PingMonitor.Service
{
    public class PingBatch
    {
        public PingBatch()
        {
            Results = new List<PingResult>();
        }

        public int Id { get; set; }
        public string MachineName { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TargetUrl { get; set; }
        public int PingTimeoutMs { get; set; }
        public List<PingResult> Results { get; set; }
        public int IntervalBetweenPingsMs { get; internal set; }
    }
}
