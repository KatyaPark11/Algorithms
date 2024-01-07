using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryTreeSortAlgorithm
{
    /// <summary>
    /// Класс, реализующий узел бинарного дерева.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Значение узла.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Левый от текущего узел.
        /// </summary>
        public TreeNode Left { get; set; }
        /// <summary>
        /// Правый от текущего узел.
        /// </summary>
        public TreeNode Right { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="value">Значение узла.</param>
        public TreeNode(int value)
        {
            // Устанавливаем указанное значение в качестве значения узла.
            Value = value;
            // Устанавливаем пустую ссылку в качестве левого от текущего узла.
            Left = null;
            // Устанавливаем пустую ссылку в качестве правого от текущего узла.
            Right = null;
        }
    }
}
