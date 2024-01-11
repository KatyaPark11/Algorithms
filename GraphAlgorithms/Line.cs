namespace Algorithms.GraphAlgorithms
{
    /// <summary>
    /// Класс, реализующий линию (ребро) графа.
    /// </summary>
    public class Line
    {
        // Вес линии (ребра).
        public int Weight { get; private set; }
        // Начальная и конечная точки линии (ребра).
        public (Point, Point) Points { get; private set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="weight">Вес линии (ребра).</param>
        /// <param name="startPoint">Начальная точка.</param>
        /// <param name="endPoint">Конечная точка.</param>
        public Line(int weight, Point startPoint, Point endPoint)
        {
            // Устанавливаем указанный вес в качестве веса ребра.
            Weight = weight;
            // Устанавливаем указанные точки в качестве начальных и конечных вершин ребра.
            Points = (startPoint, endPoint);
            // Добавляем линию (ребро) в список связанных с начальной вершиной линий.
            startPoint.LinkedLines.Add(this);
            // Добавляем линию (ребро) в список связанных с конечной вершиной линий.
            endPoint.LinkedLines.Add(this);
        }
    }
}
