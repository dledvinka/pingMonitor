namespace PingMonitor.Service
{
    public class PingResult
    {
        public int Id { get; set; }
        public long RoundtripTime { get; set; }
        public PingResultStatus Status { get; set; }
    }
}
