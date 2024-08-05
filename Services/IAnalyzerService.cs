using PointsTask.Models;

namespace PointsTask.Services;

public interface IAnalyzerService
{
    (List<Point> FurthestPoints, double MaxDistance) FindFurthestPoints(List<Point> points);
    void PrintFurthestPoints(List<Point> furthestPoints, double maxDistance, string? outputFilePath = null);
}