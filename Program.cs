namespace HashTable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            int[] keysToInsert = { 18, 26, 34, 42, 51, 40, 67, 45 };            
            LinearProbingHashTable table = new LinearProbingHashTable(8,7); // Hash table size is 8 and value to use in hash function is 7
            Console.WriteLine("table length is " + keysToInsert.Length);

            foreach (int key in keysToInsert)
                table.Insert(key);

            table.Display();

            int searchKey = 42;
            int foundIndex = table.Search(searchKey);
            if (foundIndex != -1)
                Console.WriteLine($"Key {searchKey} found at index {foundIndex}");
            else
                Console.WriteLine($"Key {searchKey} not found in the hash table");
        }
    }
}