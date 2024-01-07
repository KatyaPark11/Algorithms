using Algorithms.HashTables;

namespace Algorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            OpenAddressHashTable table = new(50);
            table.Insert(60);
            table.Insert(10);
            table.Insert(110);
            table.Remove(60);
            int? index1 = table.Contains(60);
            int? index2 = table.Contains(110);
            int? index3 = table.Contains(10);
        }
    }
}
