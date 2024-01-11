namespace Algorithms.GraphAlgorithms
{
    /// <summary>
    /// Класс, реализующий точку (вершину) графа.
    /// </summary>
    public class Point
    {
        // Имя точки (вершины).
        public int Name;
        // Флаг посещения точки (вершины).
        public bool IsVisited = false;
        // Список связанных с точкой (вершиной) линий.
        public List<Line> LinkedLines = [];
    }
}