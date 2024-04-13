namespace IP;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var commandLineArgs = CommandLineArgs.Parse(args);
            var logAnalyzer = new LogAnalyzer(commandLineArgs);
            var logEntries = logAnalyzer.SplitLogs();
            logAnalyzer.WriteResultsToFileOutput(logEntries);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
};