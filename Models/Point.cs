namespace PointsTask.Models;

public class Point
{
    public string Name { get; }

    public int X { get; }

    public int Y { get; }

    public Point(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    /// <summary>
    /// Calculates the distance of the point from the origin (0, 0) using the Euclidean distance formula.
    /// </summary>
    /// <returns>The distance of the point from the origin.</returns>
    public double DistanceFromOrigin()
    {
        int pointX = X * X;
        int pointY = Y * Y;
        return Math.Sqrt(pointX + pointY);
    }

    /// <summary>
    /// Determines the quadrant in which the point is located.
    /// </summary>
    /// <returns>
    /// A string representing the quadrant:
    /// "I" for the first quadrant,
    /// "II" for the second quadrant,
    /// "III" for the third quadrant,
    /// "IV" for the fourth quadrant,
    /// "Origin" if the point is at the origin,
    /// "X-axis" if the point is on the X-axis,
    /// "Y-axis" if the point is on the Y-axis.
    /// </returns>
    public string GetQuadrant()
    {
        return X switch
        {
            > 0 when Y > 0 => "I"
            ,
            < 0 when Y > 0 => "II"
            ,
            < 0 when Y < 0 => "III"
            ,
            > 0 when Y < 0 => "IV"
            ,
            0 when Y == 0 => "Origin"
            ,
            0 => "Y-axis"
            ,
            _ => Y == 0 ? "X-axis" : "Unknown"
        };
    }
}