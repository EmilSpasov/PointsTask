using PointsTask.Models;

namespace PointsTask.Services;

public class AppService : IAppService
{
    private readonly IParserService _pointParser;
    private readonly IAnalyzerService _pointAnalyzer;

    public AppService(IParserService pointParser, IAnalyzerService pointAnalyzer)
    {
        _pointParser = pointParser;
        _pointAnalyzer = pointAnalyzer;
    }

    public void Run(string inputFilePath, string? outputFilePath = null)
    {
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Input file not found: {inputFilePath}");
            return;
        }

        List<Point> points = new List<Point>();
        HashSet<string> uniquePoints = new HashSet<string>();

        foreach (string line in File.ReadLines(inputFilePath))
        {
            ProcessLine(line, uniquePoints, points);
        }

        if (points.Count == 0)
        {
            Console.WriteLine("No valid points found.");
            return;
        }

        var (furthestPoints, maxDistance) = _pointAnalyzer.FindFurthestPoints(points);
        _pointAnalyzer.PrintFurthestPoints(furthestPoints, maxDistance, outputFilePath);
    }

    private void ProcessLine(string line, HashSet<string> uniquePoints, List<Point> points)
    {
        string trimmedLine = line.Trim();
        if (string.IsNullOrWhiteSpace(trimmedLine))
        {
            Console.WriteLine("Skipping empty line.");
            return;
        }

        try
        {
            Point point = _pointParser.Parse(trimmedLine);

            string pointKey = $"{point.X},{point.Y}";
            if (uniquePoints.Contains(pointKey))
            {
                Console.WriteLine($"Duplicate point found: {trimmedLine}");
                return;
            }

            if (Math.Abs(point.X) > int.MaxValue || Math.Abs(point.Y) > int.MaxValue)
            {
                Console.WriteLine($"Point with very large/small coordinates found: {trimmedLine}");
                return;
            }

            uniquePoints.Add(pointKey);
            points.Add(point);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Failed to parse line: {line}. Error: {ex.Message}");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Overflow error while parsing line: {line}. Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while parsing line: {line}. Error: {ex.Message}");
        }
    }
}