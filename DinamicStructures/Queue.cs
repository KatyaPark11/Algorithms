namespace Algorithms.DinamicStructures
{
    /// <summary>
    /// Класс, реализующий очередь.
    /// </summary>
    /// <typeparam name="T">Тип данных элементов очереди.</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Элементы очереди.
        /// </summary>
        public LinkedList<T> elements = new();

        /// <summary>
        /// Метод, добавляющий элемент в конец очереди.
        /// </summary>
        /// <param name="item">Добавляемый элемент.</param>
        public void Enqueue(T item) => elements.AddTail(item);

        /// <summary>
        /// Метод, реализующий возврат первого элемента очереди.
        /// </summary>
        /// <returns>Извлечённый элемент или значение по умолчанию, если очередь была пуста.</returns>
        public T? Dequeue()
        {
            // Проверяем, есть ли хотя бы один элемент.
            try
            {
                // Если элемент есть:
                // Устанавливаем значение элемента вершины в качестве возвращаемого значения.
                T? value = elements.Head.Value;
                // Удаляем возвращаемый элемент из очереди.
                elements.RemoveHead();
                // Возвращаем значение.
                return value;
            }
            catch
            {
                // Если элементов нет:
                // Пишем об отсутствии элементов в очереди.
                Console.WriteLine("В очереди больше нет элементов, возвращено значение по умолчанию.");
                // Возвращаем значение по умолчанию.
                return default;
            }
        }
    }
}
