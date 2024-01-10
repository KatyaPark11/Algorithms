namespace Algorithms.ExternalSortAlgorithms
{
    /// <summary>
    /// Класс, реализующий внешнюю сортировку многопутевым прямым слиянием.
    /// </summary>
    public class ExternalMultiDirectMergeSort
    {
        /// <summary>
        /// Метод, реализующий внешнюю сортировку многопутевым прямым слиянием.
        /// </summary>
        /// <param name="inputPath">Путь к файлу с массивом для сортировки.</param>
        /// <param name="threadsNum">Число потоков.</param>
        public static void Sort(string inputPath, int threadsNum)
        {
            // Проверяем, допустимо ли введённое количество путей.
            if (threadsNum > 25)
            {
                // Выводим сообщение об ошибке.
                Console.WriteLine("Указано слишком большое число путей. Сортировка не выполнена.");
                // Выходим из метода.
                return;
            }
            // Копируем файл с массивом для сортировки в файл с будущим отсортированным массивом.
            File.Copy(inputPath, "fileA.txt", true);
            // Устанавливаем единицу в качестве числа сегментов.
            int segments = 1;
            // Устанавливаем единицу в качестве шага.
            int step = 1;
            // Пока после разделения на файлы не останется один сегмент, выполняем сортировку.
            while (true)
            {
                // Разделяем файл с будущим отсортированным массивом в соответствии с заданным шагом.
                SplitToFiles(ref segments, step, threadsNum);
                // Если остался один сегмент, прекращаем сортировку.
                if (segments == 1) break;
                // Сливаем временные файлы в файл с будущим отсортированным массивом.
                MergeFiles(ref step, threadsNum);
            }

            // Пробегаемся от нуля до числа путей.
            for (int i = 0; i < threadsNum; i++)
                // Удаляем текущий временный файл.
                File.Delete($"file{(char)('B' + i)}.txt");
        }

        /// <summary>
        /// Метод, реализующий разделение файла с будущим отсортированным массивом в соответствии с заданным шагом.
        /// </summary>
        /// <param name="segments">Число сегментов.</param>
        /// <param name="step">Шаг.</param>
        /// <param name="threadsNum">Число потоков.</param>
        private static void SplitToFiles(ref int segments, int step, int threadsNum)
        {
            // Устанавливаем единицу в качестве числа сегментов.
            segments = 1;
            // Устанавливаем считыватель из файла с будущим отсортированным массивом.
            using StreamReader fileA = new("fileA.txt");
            // Устанавливаем заданное число ссылок в качестве записывателей во временные файлы.
            StreamWriter[] writers = new StreamWriter[threadsNum];
            // Пробегаемся от нуля до числа путей.
            for (int i = 0; i < threadsNum; i++)
                // Устанавливаем путь к файлу для текущего записывателя.
                writers[i] = new($"file{(char)('B' + i)}.txt");
            // Устанавливаем ноль в качестве флага для определения того, куда будет записано текущее число.
            int flag = 0;
            // Устанавливаем ноль в качестве счётчика для отслеживания перехода к следующему файлу.
            int counter = 0;
            // Объявляем текущее взятое число.
            string? curNum;

            // Пока строки в файле с будущим отсортированным массивом не закончились, продолжаем разделение на файлы.
            while ((curNum = fileA.ReadLine()) != null)
            {
                // Проверяем, дошёл ли счётчик до конца шага.
                if (counter == step)
                {
                    // Если счётчик дошёл до конца:
                    // Обнуляем счётчик.
                    counter = 0;
                    // Переходим к следующему файлу.
                    flag = (flag + 1) % threadsNum;
                    // Инкрементируем число сегментов.
                    segments++;
                }

                // Записываем число в текущий, соответствующий флагу, файл.
                writers[flag].WriteLine(curNum);
                // Инкрементируем счётчик.
                counter++;
            }

            // Пробегаемся по записывателям во временные файлы.
            foreach (StreamWriter writer in writers)
                // Закрываем поток.
                writer.Dispose();
        }

        /// <summary>
        /// Метод, реализующий слияние временных файлов в файл с будущим отсортированным массивом.
        /// </summary>
        /// <param name="step">Шаг.</param>
        /// <param name="threadsNum">Число потоков.</param>
        private static void MergeFiles(ref int step, int threadsNum)
        {
            // Устанавливаем записыватель в файл с будущим отсортированным массивом.
            using StreamWriter fileA = new("fileA.txt");
            // Устанавливаем заданное число ссылок в качестве считывателей из временных файлов.
            StreamReader[] readers = new StreamReader[threadsNum];
            // Пробегаемся от нуля до числа путей.
            for (int i = 0; i < threadsNum; i++)
                // Устанавливаем путь к файлу для текущего считывателя.
                readers[i] = new($"file{(char)('B' + i)}.txt");
            // Устанавливаем заданное число ссылок в качестве элементов из временных файлов.
            string?[] elements = new string?[readers.Length];
            // Пробегаемся от нуля до числа считывателей.
            for (int i = 0; i < readers.Length; i++)
                // Считываем первую строку из каждого временного файла.
                elements[i] = readers[i].ReadLine();
            // Устанавливаем нули (по умолчанию) в качестве счётчиков для файлов для отслеживания перехода к следующему файлу.
            int[] counters = new int[readers.Length];

            // Пока строки во временных файлах не закончились, продолжаем сортировку.
            while (elements.Any(e => e != null))
            {
                // Устанавливаем заданное число ссылок в качестве копии элементов из временных файлов.
                string?[] tempElements = new string?[elements.Length];
                // Копируем массив элементов.
                Array.Copy(elements, tempElements, elements.Length);
                // Пробегаемся от нуля до числа элементов.
                for (int i = 0; i < tempElements.Length; i++)
                    // Проверяем, дошёл ли счётчик до конца.
                    if (counters[i] == step)
                        // Если счётчик дошёл до конца шага, не учитываем элемент текущего файла.
                        tempElements[i] = null;
                // Устанавливаем минимальный индекс среди копии элементов.
                int minIndex = GetMinIndex(tempElements);
                // Записываем текущее число в файл с будущим отсортированным массивом.
                fileA.WriteLine(elements[minIndex]);
                // Считываем следующую строку из текущего файла.
                elements[minIndex] = readers[minIndex].ReadLine();
                // Инкрементируем счётчик для текущего файла.
                counters[minIndex]++;

                // Фиксируем значение шага.
                int fixedStep = step;
                // Если счётчики не дошли до конца шага хотя бы для одного файла, то переходим к следующей итерации.
                if (counters.Any(c => c != fixedStep)) continue;
                // Если счётчики дошли до конца для всех временных файлов:
                // Пробегаемся от нуля до числа счётчиков.
                for (int i = 0; i < counters.Length; i++)
                    // Обнуляем текущий счётчик.
                    counters[i] = 0;
            }

            // Увеличиваем шаг в n раз, где n - число считывателей.
            step *= readers.Length;

            // Пробегаемся по считывателям из временных файлов.
            foreach (var reader in readers)
                // Закрываем поток.
                reader.Dispose();
        }

        /// <summary>
        /// Метод, реализующий получение индекса минимального элемента в заданном массиве.
        /// </summary>
        /// <param name="elements">Массив для поиска индекса минимального элемента.</param>
        private static int GetMinIndex(string?[] elements)
        {
            // Устанавливаем -1 в качестве индекса минимального элемента.
            int minIndex = -1;
            // Устанавливаем максимальное целочисленное значение в качестве минимального элемента.
            int minValue = int.MaxValue;

            // Пробегаемся по массиву n раз, где n - длина массива.
            for (int i = 0; i < elements.Length; i++)
            {
                // Проверяем, есть ли элемент по данному индексу.
                if (elements[i] != null)
                {
                    // Если элемент есть:
                    // Конвертируем значение из строки в целое число.
                    int num = int.Parse(elements[i]);
                    // Сравниваем текущий элемент с минимальным.
                    if (num < minValue)
                    {
                        // Если текущий элемент меньше минимального:
                        // Меняем минимальный элемент на текущий.
                        minValue = num;
                        // Меняем индекс минимального элемента на индекс текущего.
                        minIndex = i;
                    }
                }
            }

            // Возвращаем индекс минимального элемента.
            return minIndex;
        }
    }
}
