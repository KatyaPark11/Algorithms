using Algorithms.ExternalSortAlgorithms;

namespace Algorithms
{
    public class Program
    {
        public static void Main()  
        {
            int[] array = { 63, 5, 1, 31, 82, 72, 33, 93, 24, 95 };
            ExternalMultiDirectMergeSort.Sort("input.txt", 25);
        }
    }

    public class MyNode<T>
    {
        public T Value;
        public MyNode<T> Next;
        public MyNode<T> Previous;

        public MyNode(T value) => Value = value;
    }

    public class MyLinkedList<T>
    {
        public MyNode<T> Head;
        public MyNode<T> Tail;

        public void AddHead(T newValue)
        {
            MyNode<T> newNode = new(newValue);
            if (Head != null)
            {
                Head.Previous = newNode;
                newNode.Next = Head;
            }
            else
            {
                Tail = newNode;
            }

            Head = newNode;
        }

        public void AddTail(T newValue)
        {
            MyNode<T> newNode = new(newValue);
            if (Tail != null)
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
            }
            else
            {
                Head = newNode;
            }

            Tail = newNode;
        }

        public void RemoveHead()
        {
            if (Head == null) return;
            if (Head != Tail)
            {
                Head = Head.Next;
                Head.Previous.Next = null;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
        }

        public void RemoveTail()
        {
            if (Tail == null) return;
            if (Head != Tail)
            {
                Tail = Tail.Previous;
                Tail.Next.Previous = null;
                Tail.Next = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
        }
    }

    public class MyStack<T>
    {
        public MyLinkedList<T> Stack = new();

        public void Push(T newValue) => Stack.AddTail(newValue);

        public T? Pop()
        {
            try
            {
                T? value = Stack.Tail.Value;
                Stack.RemoveTail();
                return value;
            }
            catch
            {
                Console.WriteLine("В стеке нет элементов, возвращено значение по умолчанию.");
                return default;
            }
        }
    }

    public class MyQueue<T>
    {
        public MyLinkedList<T> Queue = new();

        public void Enqueue(T newValue) => Queue.AddTail(newValue);

        public T? Dequeue()
        {
            try
            {
                T? value = Queue.Head.Value;
                Queue.RemoveHead();
                return value;
            }
            catch
            {
                Console.WriteLine("В очереди нет элементов, возвращено значение по умолчанию.");
                return default;
            }
        }
    }
}
