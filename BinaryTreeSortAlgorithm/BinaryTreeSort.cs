namespace Algorithms.BinaryTreeSortAlgorithm
{
    /// <summary>
    /// Класс, реализующий сортировку с помощью бинарного дерева.
    /// </summary>
    public class BinaryTreeSort
    {
        /// <summary>
        /// Корень текущего бинарного дерева.
        /// </summary>
        private TreeNode? root;

        /// <summary>
        /// Метод, реализующий сортировку с помощью бинарного дерева.
        /// </summary>
        /// <param name="array">Массив для сортировки.</param>
        /// <returns>Отсортированный массив.</returns>
        public int[] Sort(int[] array)
        {
            // Обнуляем корень бинарного дерева.
            root = null;
            // Пробегаемся по массиву.
            foreach (int value in array)
                // Вставляем элемент в бинарное дерево.
                Insert(value);

            // Устанавливаем пустой список в качестве будущего отсортированного списка.
            List<int> sortedList = [];
            // Обходим бинарное дерево с целью получения отсортированного списка.
            InOrderTraversal(root, sortedList);
            // Возвращаем отсортированный массив.
            return [.. sortedList];
        }

        /// <summary>
        /// Метод, реализующий вставку элемента в бинарное дерево.
        /// </summary>
        /// <param name="value">Значение элемента для вставки.</param>
        private void Insert(int value)
        {
            // Проверяем, есть ли в дереве хотя бы один элемент.
            if (root == null)
                // Если элементов нет, то устанавливаем указанное значение в качестве корня текущего бинарного дерева.
                root = new TreeNode(value);
            else
                // Если есть хотя бы один элемент, вставляем его на нужное место.
                InsertNode(root, value);
        }

        /// <summary>
        /// Метод, реализующий вставку элемента на нужное место.
        /// </summary>
        /// <param name="node">Узел, на котором мы находимся на данный момент.</param>
        /// <param name="value">Значение элемента для вставки.</param>
        private void InsertNode(TreeNode? node, int value)
        {
            // Сравниваем значение элемента для вставки со значением текущего узла.
            if (value < node.Value)
            {
                // Если значение элемента для вставки меньше значения текущего узла:
                // Проверяем, есть ли левый от текущего узел.
                if (node.Left == null)
                    // Если узла нет, то вставляем на его место элемент для вставки.
                    node.Left = new TreeNode(value);
                else
                    // Если узел есть, то меняем на него текущий узел.
                    InsertNode(node.Left, value);
            }
            else
            {
                // Если значение элемента для вставки нестрого больше значения текущего узла:
                // Проверяем, есть ли правый от текущего узел.
                if (node.Right == null)
                    // Если узла нет, то вставляем на его место элемент для вставки.
                    node.Right = new TreeNode(value);
                else
                    // Есть узел есть, то меняем на него текущий узел.
                    InsertNode(node.Right, value);
            }
        }

        /// <summary>
        /// Метод, реализующий обход бинарного дерева в отсортированном порядке.
        /// </summary>
        /// <param name="node">Узел, на котором мы находимся на данный момент.</param>
        /// <param name="sortedList">Будущий отсортированный список.</param>
        private void InOrderTraversal(TreeNode? node, List<int> sortedList)
        {
            // Проверяем, есть ли ссылка у данного узла.
            if (node != null)
            {
                // Если ссылка есть:
                // Переходим к левому от текущего узлу.
                InOrderTraversal(node.Left, sortedList);
                // Добавляем значение текущего узла в будущий отсортированный список.
                sortedList.Add(node.Value);
                // Переходим к правому от текущего узлу.
                InOrderTraversal(node.Right, sortedList);
            }
        }
    }
}
