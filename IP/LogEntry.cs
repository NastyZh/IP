using System.Net;

namespace IP;

public class LogEntry
{
    public IPAddress Ip { get; set; }

    public DateTime Timestampt { get; set; }

    public LogEntry(IPAddress ip, DateTime timestamp)
    {
        Ip = ip;
        Timestampt = timestamp;
    }
}