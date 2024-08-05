namespace PointsTask.Services;

public interface IAppService
{
    void Run(string inputFilePath, string? outputFilePath = null);
}