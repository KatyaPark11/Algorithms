using Algorithms.GraphAlgorithms;
using System.ComponentModel.Design;
using System.Net;

namespace Algorithms
{
    public class Program
    {
        public static void Main()
        {
            //int[] array = { 63, 5, 1, 31, 82, 72, 33, 93, 24, 95 };
            //string[] array = { "my", "name", "is", "pypa", "and", "he", "is", "pupa", "1", "51" };
            List<Point> points =
            [
                new(),
                new(),
                new(),
                new(),
                new()
            ];
            List<Line> lines =
            [
                new(4, points[0], points[1]),
                new(5, points[1], points[2]),
                new(7, points[1], points[3]),
                new(9, points[2], points[3]),
                new(6, points[2], points[4])
            ];
            var pyp = GraphAlgorithms.Algorithms.Kruskal(lines);
        }
    }
}
