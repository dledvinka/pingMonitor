using System;
using System.Timers;

namespace PingMonitor.Service
{
    public class PingMonitorJob
    {
        readonly Timer _timer;
        private readonly PingMonitorJobConfiguration _config;

        public PingMonitorJob(PingMonitorJobConfiguration config)
        {
            _config = config;

            _timer = new Timer(_config.BatchInterval.TotalMilliseconds) { AutoReset = true };
            _timer.Elapsed += OnTimer;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            RunJob();
        }

        private void RunJob()
        {
            PingBatch batch = ExecuteBatch();
            Console.WriteLine("Batch finished");
            StoreResult(batch);
            Console.WriteLine("Batch stored");
        }

        private int StoreResult(PingBatch batch)
        {
            using (PingContext context = new PingContext())
            {
                context.Batches.Add(batch);
                return context.SaveChanges();
            }
        }

        private PingBatch ExecuteBatch()
        {
            PingBatch batch = new PingBatch()
            {
                MachineName = Environment.MachineName,
                PingTimeoutMs = (int)_config.PingTimeout.TotalMilliseconds,
                IntervalBetweenPingsMs = (int)_config.IntervalBetweenPings.TotalMilliseconds,
                TargetUrl = _config.TargetUrl,
                TimeStamp = DateTime.Now
            };

            for (int i = 0; i < _config.BatchSize; i++)
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var pingResult = ping.Send(_config.TargetUrl, (int)_config.PingTimeout.TotalMilliseconds);
                Console.WriteLine(pingResult.Status.ToString() + " - " + pingResult.RoundtripTime);

                PingResult result = new PingResult()
                {
                    Status = (PingResultStatus)pingResult.Status,
                    RoundtripTime = pingResult.RoundtripTime
                };

                batch.Results.Add(result);

                System.Threading.Thread.Sleep(_config.IntervalBetweenPings);
            }

            return batch;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
