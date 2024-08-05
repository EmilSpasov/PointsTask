using PointsTask.Services;

namespace PointsTask;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Provide input file path.");
        string? inputFilePath = Console.ReadLine();

        if (string.IsNullOrEmpty(inputFilePath))
        {
            Console.WriteLine("Invalid file");
            Environment.Exit(1);
        }

        Console.WriteLine("Choose output file name e.g. 'output.txt' or leave empty to print result in Console.");
        string? outputFilePath = Console.ReadLine();

        IParserService parserService = new ParserService();
        IAnalyzerService analyzerService = new AnalyzerService();
        IAppService appService = new AppService(parserService, analyzerService);

        appService.Run(inputFilePath, outputFilePath);
    }
}