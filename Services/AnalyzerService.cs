using System.Text;
using PointsTask.Models;

namespace PointsTask.Services;

public class AnalyzerService : IAnalyzerService
{
    /// <summary>
    /// Finds the point(s) that are furthest from the origin (0, 0).
    /// </summary>
    /// <param name="points">The list of points to analyze.</param>
    /// <returns>A tuple containing the list of furthest points and the maximum distance.</returns>
    public (List<Point> FurthestPoints, double MaxDistance) FindFurthestPoints(List<Point> points)
    {
        // Calculate the maximum distance from the origin among all points
        double maxDistance = points.Max(p => p.DistanceFromOrigin());

        // Find all points that are at the maximum distance from the origin
        // The threshold 1e-6 is used to compare floating-point numbers for equality
        List<Point> furthestPoints = points.Where(p => Math.Abs(p.DistanceFromOrigin() - maxDistance) < 1e-6).ToList();

        return (furthestPoints, maxDistance);
    }

    /// <summary>
    /// Prints the furthest points to the console or to a file.
    /// </summary>
    /// <param name="furthestPoints">The list of furthest points.</param>
    /// <param name="maxDistance">The maximum distance from the origin.</param>
    /// <param name="outputFilePath"></param>
    public void PrintFurthestPoints(List<Point> furthestPoints, double maxDistance, string? outputFilePath = null)
    {
        if (string.IsNullOrWhiteSpace(outputFilePath))
        {
            Console.WriteLine("The point(s) furthest from the origin (0, 0):");

            foreach (Point point in furthestPoints)
            {
                Console.WriteLine($"{point.Name} at ({point.X}, {point.Y}), Distance: {maxDistance}, Quadrant: {point.GetQuadrant()}");
            }

            return;
        }

        try
        {
            if (!Path.IsPathRooted(outputFilePath))
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string projectDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\"));
                outputFilePath = Path.Combine(projectDirectory, outputFilePath);
            }

            using FileStream fs = File.Create(outputFilePath);
            using StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
            writer.WriteLine("The point(s) furthest from the origin (0, 0):");

            foreach (Point point in furthestPoints)
            {
                writer.WriteLine($"{point.Name} at ({point.X}, {point.Y}), Distance: {maxDistance}, Quadrant: {point.GetQuadrant()}");
            }

            Console.WriteLine($"Output written to {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write to file: {ex.Message}");
        }
    }
}