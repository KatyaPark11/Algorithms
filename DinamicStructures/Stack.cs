namespace Algorithms.DinamicStructures
{
    /// <summary>
    /// Класс, реализующий стек.
    /// </summary>
    /// <typeparam name="T">Тип данных элементов стека.</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// Элементы стека.
        /// </summary>
        public LinkedList<T> elements = new();
        
        /// <summary>
        /// Метод, реализующий добавление элемента на вершину стека.
        /// </summary>
        /// <param name="value">Добавляемый элемент.</param>
        public void Push(T value) => elements.AddHead(value);

        /// <summary>
        /// Метод, реализующий возврат элемента с вершины стека.
        /// </summary>
        /// <returns>Извлечённый элемент или значение по умолчанию, если стек был пуст.</returns>
        public T? Pop()
        {
            // Проверяем, есть ли хотя бы один элемент.
            try
            {
                // Если элемент есть:
                // Устанавливаем значение элемента вершины в качестве возвращаемого значения.
                T? value = elements.Head.Value;
                // Удаляем возвращаемый элемент из стека.
                elements.RemoveHead();
                // Возвращаем значение.
                return value;
            }
            catch
            {
                // Если элементов нет:
                // Пишем об отсутствии элементов в стеке.
                Console.WriteLine("В стеке больше нет элементов, возвращено значение по умолчанию.");
                // Возвращаем значение по умолчанию.
                return default;
            }
        }
    }
}
