namespace Algorithms.HashTables
{
    /// <summary>
    /// Класс, реализующий хэш-таблицу с методом разрешения коллизий с помощью открытой аддресации.
    /// </summary>
    public class OpenAddressHashTable
    {
        /// <summary>
        /// Размер таблицы.
        /// </summary>
        public int Size;
        /// <summary>
        /// Значения, хранимые в таблице.
        /// </summary>
        private int?[] hashTable;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="size">Размер хэш-таблицы.</param>
        public OpenAddressHashTable(int size)
        {
            // Устанавливаем указанное значение в качестве размера таблицы.
            Size = size;
            // Устанавливаем массив со значениями по умолчанию в качестве хэш-таблицы.
            hashTable = new int?[size];
        }

        /// <summary>
        /// Метод, реализующий вставку нового элемента в таблицу.
        /// </summary>
        /// <param name="key">Вставляемый элемент.</param>
        public void Insert(int key)
        {
            // Пробегаемся по массиву n раз, где n - длина массива.
            for (int i = 0; i < hashTable.Length; i++)
            {
                // Устанавливаем хэш, полученный линейным методом, в качестве хэша вставляемого элемента.
                int hash = (key + i) % Size;
                // Проверяем, является ли текущая ячейка пустой.
                if (hashTable[hash] == null)
                {
                    // Если текущая ячейка является пустой:
                    // Вставляем элемент в ячейку.
                    hashTable[hash] = key;
                    // Выходим из метода.
                    return;
                }
            }
        }

        /// <summary>
        /// Метод, реализующий поиск элемента в хэш-таблице.
        /// </summary>
        /// <param name="key">Искомый элемент.</param>
        /// <returns>Индекс (хэш) искомого элемента, или null, если элемент не найден.</returns>
        public int? Contains(int key)
        {
            // Пробегаемся по массиву n раз, где n - длина массива.
            for (int i = 0; i < hashTable.Length; i++)
            {
                // Устанавливаем хэш, полученный линейным методом, в качестве хэша вставляемого элемента.
                int hash = (key + i) % Size;
                // Если текущий элемент искомый, то возвращаем его хэш.
                if (hashTable[hash] == key) return hash;
            }
            // Если все ячейки в таблице заняты, а элемента там нет, то возвращаем пустую ссылку.
            return null;
        }

        /// <summary>
        /// Метод, реализующий удаление элемента из хэш-таблицы.
        /// </summary>
        /// <param name="key">Удаляемый элемент.</param>
        public void Remove(int key)
        {
            // Устанавливаем индекс элемента в таблице при его наличии в качестве хэша удаляемого элемента.
            int? hash = Contains(key);
            // Проверяем, находится ли элемент в таблице.
            if (hash != null)
                // Если элемент находится в таблице, то удаляем его.
                hashTable[(int)hash] = null;
        }
    }
}
