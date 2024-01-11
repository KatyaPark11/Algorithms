namespace Algorithms
{
    /// <summary>
    /// Класс, реализующий поразрядную сортировку.
    /// </summary>
    public static class RadixSort
    {
        // Метод для выполнения радиксной сортировки для строк
        public static void Sort(string[] array)
        {
            // Устанавливаем максимальную длину.
            int maxLen = GetMax(array);

            // Пробегаемся от максимальной длины массива минус один до нуля.
            for (int i = maxLen - 1; i >= 0; i--)
                // Сортируем массив по текущему разряду.
                CountSort(array, i);
        }

        /// <summary>
        /// Метод, реализующий получение значения максимального элемента массива.
        /// </summary>
        /// <param name="array">Массив для поиска элементов.</param>
        /// <returns>Максимальная длина.</returns>
        private static int GetMax(string[] array)
        {
            // Устанавливаем -1 в качестве будущей максимальной длины.
            int maxLen = -1;
            // Пробегаемся по массиву.
            foreach (string str in array)
                // Проверяем наличие элемента и сравниваем длину текущего элемента массива и текущую максимальную длину.
                if (str != null && str.Length > maxLen)
                    // Если элемент есть и длина текущего элемента больше текущей максимальной, то меняем на неё значение максимальной длины.
                    maxLen = str.Length;
            // Возвращаем максимальную длину.
            return maxLen;
        }

        /// <summary>
        /// Метод, реализующий сортировку массива по заданному разряду.
        /// </summary>
        /// <param name="array">Массив для сортировки.</param>
        /// <param name="currentRadix">Заданный разряд.</param>
        static void CountSort(string[] array, int exp)
        {
            // Устанавливаем 256 в качестве количества существующих символов в ASCII.
            const int CHAR_RANGE = 256;
            // Устанавливаем пустой массив списков в качестве счётчиков встречаемых цифр в заданном разряде.
            List<string>[] counts = new List<string>[CHAR_RANGE];

            // Пробегаемся по массиву списков.
            for (int i = 0; i < counts.Length; i++)
                // Инициализируем соответствующий список.
                counts[i] = [];

            // Пробегаемся по массиву строк.
            foreach (var str in array)
            {
                // Устанавливаем соответствующий индекс символа.
                int index = (exp < str.Length) ? str[exp] : 0;
                // Добавляем текущую строку в соответствующий список.
                counts[index].Add(str);
            }

            // Устанавливаем ноль в качестве текущего индекса.
            int curIndex = 0;
            // Пробегаемся по массиву n раз, где n - длина массива.
            for (int i = 0; i < counts.Length; i++)
                // Пробегаемся по списку в соответствующем массиве.
                foreach (var str in counts[i])
                    // Записываем в массив соответствующую строку списка.
                    array[curIndex++] = str;
        }
    }
}
