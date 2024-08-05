using PointsTask.Models;

namespace PointsTask.Services;

public class ParserService : IParserService
{
    /// <summary>
    /// Parses a line of text to create a Point object.
    /// </summary>
    /// <param name="line">The line of text to parse.</param>
    /// <returns>A Point object.</returns>
    /// <exception cref="FormatException">Thrown when the line format is invalid.</exception>
    public Point Parse(string line)
    {
        int nameEndIndex = line.IndexOf('(');
        int coordStartIndex = nameEndIndex + 1;
        int coordEndIndex = line.IndexOf(')', coordStartIndex);

        if (nameEndIndex == -1 || coordEndIndex == -1)
        {
            throw new FormatException("Invalid point format. Missing parentheses.");
        }

        string pointName = line.Substring(0, nameEndIndex);

        string coordsString = line.Substring(coordStartIndex, coordEndIndex - coordStartIndex);
        
        string[] coords = coordsString.Split(',')
            .Select(coord => coord.Trim())
            .ToArray();

        if (coords.Length != 2)
        {
            throw new FormatException("Invalid coordinates format. Should contain exactly two values.");
        }

        // Try to parse the x and y coordinates
        if (!int.TryParse(coords[0], out int x) || !int.TryParse(coords[1], out int y))
        {
            throw new FormatException("Coordinates must be integers.");
        }

        return new Point(pointName, x, y);
    }
}