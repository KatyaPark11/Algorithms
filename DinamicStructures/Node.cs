namespace Algorithms.DinamicStructures
{
    /// <summary>
    /// Класс, реализующий элемент связного списка.
    /// </summary>
    /// <typeparam name="T">Тип данных элементов связного списка.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Значение текущего элемента.
        /// </summary>
        public T Value;
        /// <summary>
        /// Следующий для текущего элемент.
        /// </summary>
        public Node<T>? Next;
        /// <summary>
        /// Предыдущий для текущего элемент.
        /// </summary>
        public Node<T>? Previous;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="value">Значение элемента.</param>
        public Node (T value) => Value = value;
    }
}
