using PointsTask.Models;

namespace PointsTask.Services;

public interface IParserService
{
    Point Parse(string line);
}