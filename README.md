# PointsTask Console Application

## Overview
The PointsTask console application reads a list of 2D points from an input file, identifies the point(s) furthest from the origin (0, 0), and outputs these points along with their quadrant information. The result can be displayed on the console or written to an output file.

## Project Structure
The project is organized into several classes, each with a specific responsibility:

- `Program.cs`: Entry point of the application.
- `Point.cs`: Represents a point in a 2D coordinate system.
- `ParserService.cs`: Parses input lines into `Point` objects.
- `AnalyzerService.cs`: Analyzes points to find the furthest ones and prints the results.
- `AppService.cs`: Manages the application's flow, including reading the input file, processing lines, and invoking the parser and analyzer services.

## Getting Started

### Prerequisites
- .NET 6 SDK installed on your machine.
- An input file with points data in the format `PointNo(x, y)` (e.g., `Point1(2, 3)`).

### Build and Run

1. **Clone the Repository**
    ```bash
    git clone <https://github.com/EmilSpasov/PointsTask.git>
    cd PointsTask
    ```

2. **Build the Application**
    ```bash
    dotnet build
    ```

3. **Run the Application**
    ```bash
    dotnet run -- TextFiles/points.txt [output_file_path]
    ```
    - `TextFiles/points.txt`: Path to the input file containing points.
    - `[output_file_path]` (optional): Path to the output file where results will be written. If not provided, results will be printed to the console.

### Example Usage
```bash
dotnet run -- TextFiles/points.txt output.txt
