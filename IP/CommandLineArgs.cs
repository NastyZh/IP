namespace IP;

public class CommandLineArgs
{
    public string FileLog { get; private init; }
    public string FileOutput { get; private init; }
    public string AddressStart { get; private init; }
    public string AddressMask { get; private init; }
    public DateTime TimeStart { get; private init; }
    public DateTime TimeEnd { get; private init; }

    public static CommandLineArgs Parse(string[] args)
    {
        if (args.Length < 4 || args.Length > 6)
        {
            throw new ArgumentException("Неверное колчество аргументов командной строки. ");
        }

        var fileName = args[0];
        var fileOutput = args[1];
        var addressStart = args[2];
        var addressMask = args[3];
        var timeStart = args[4];
        var timeEnd = args[5];

        if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(fileOutput) ||
            string.IsNullOrEmpty(addressStart) || string.IsNullOrEmpty(addressMask) ||
            string.IsNullOrEmpty(timeStart) || string.IsNullOrEmpty(timeEnd))
        {
            throw new ArgumentException("Все аргументы командной строки должны быть заполнены.");
        }

        DateTime timeStartResult, timeEndResult;

        if (!DateTime.TryParseExact(timeStart, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None,
                out timeStartResult) ||
            !DateTime.TryParseExact(timeEnd, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None,
                out timeEndResult))
        {
            throw new ArgumentException(
                "Ошибка при разборе времени. Убедитесь, что время указано в формате dd.MM.yyyy");
        }

        if (timeStartResult >= timeEndResult)
        {
            throw new ArgumentException("Время начала интервала должно быть раньше времени окончания интервала.");
        }


        return new CommandLineArgs
        {
            FileLog = fileName,
            FileOutput = fileOutput,
            AddressMask = addressMask,
            AddressStart = addressStart,
            TimeStart = timeStartResult,
            TimeEnd = timeEndResult
        };
    }
}

