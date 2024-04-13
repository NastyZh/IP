using IP;

namespace IPTest;

public class IpLogTests
{
    // проверяю, возвращается ли объект типа "CommandLineArgs" при передаче корректных аргументов командной строки

    [Test]
    public void IP_CorrectArguments_ReturnsCommandLineArgsObject()
    {
        string[] args = { "file.txt", "output.txt", "192.168.0.1", "255.255.255.0", "09.04.2023", "10.04.2023" };

        CommandLineArgs.Parse(args);
        var result = CommandLineArgs.Parse(args);
        Assert.IsNotNull(result);
    }
}