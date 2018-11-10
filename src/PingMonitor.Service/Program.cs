using System;
using Topshelf;

namespace PingMonitor.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var config = new PingMonitorJobConfiguration()
            {
                BatchInterval = TimeSpan.FromMinutes(30),
                BatchSize = 20,
                PingTimeout = TimeSpan.FromSeconds(4),
                IntervalBetweenPings = TimeSpan.FromSeconds(5),
                TargetUrl = "www.seznam.cz"
            };

            var rc = HostFactory.Run(x =>
            {
                x.Service<PingMonitorJob>(s =>
                {
                    s.ConstructUsing(name => new PingMonitorJob(config));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("PingMonitor");
                x.SetDisplayName("PingMonitor");
                x.SetServiceName("PingMonitor");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
