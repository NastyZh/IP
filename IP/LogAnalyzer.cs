using System.Net;
namespace IP;

public class LogAnalyzer
{
    private readonly CommandLineArgs _commandLineArgs;
    private readonly IpConversion _ipConversion;

    public LogAnalyzer(CommandLineArgs commandLineArgs)
    {
        _commandLineArgs = commandLineArgs;
        _ipConversion =new IpConversion();
    }

    public List<LogEntry> SplitLogs()
    {
        var filePath = _commandLineArgs.FileLog;
        var addressStart = _ipConversion.GetIpAddress(_commandLineArgs.AddressStart);
        var addressMask = _ipConversion.GetIpAddress(_commandLineArgs.AddressMask);
        IPAddress addressEnd = _ipConversion.GetUpperBoundAddress(addressStart, addressMask);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл логов не найден.", filePath);
        }

        using StreamReader reader = new StreamReader(filePath);
        string line;
        List<LogEntry> logEntries = new List<LogEntry>();
        while ((line = reader.ReadLine()) != null)
        {
            var separator = line.Split(":");
            var ip = _ipConversion.GetIpAddress(separator[0]);
            var timestamp = separator[1];


            if (DateTime.TryParse(timestamp, out DateTime newTimestamp) && newTimestamp >= _commandLineArgs.TimeStart &&
                newTimestamp <= _commandLineArgs.TimeEnd)
            {
                var ipInformation = new LogEntry(ip, newTimestamp);
                logEntries.Add(ipInformation);
            }
        }

        return logEntries;
    }

   

    public void WriteResultsToFileOutput(List<LogEntry> logEntries)
    {
        var filePath = _commandLineArgs.FileOutput;
        if (!File.Exists(filePath))
        {
            using var fileStream = File.Create(filePath);
        }

        using StreamWriter writer = new StreamWriter(filePath);

        foreach (var logEntry in logEntries)
        {
            writer.WriteLine($"{logEntry.Ip}:{logEntry.Timestampt}");
        }
    }

  
}