using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class LinearProbingHashTable
    {
        private int[] hashTable;
        private int tableSize, hashValue, emptyValue = -1; // Use -1 to indicate empty slot

        // Constructor
        public LinearProbingHashTable(int tableSize,int hash)
        {            
            this.tableSize = tableSize;
            hashValue = hash;
            hashTable = new int[tableSize];
            for (int i = 0; i < tableSize; i++)
                hashTable[i] = emptyValue;                        
        }
        private int Hash(int key)
        {            
            return key % hashValue;
        }
        // Insert using linear probing
        public void Insert(int key)
        {
            int index = Hash(key);
            int startIndex = index;

            while (hashTable[index] != emptyValue)
            {
                Console.WriteLine($"Collision at index {index} for key {key}, trying next index...");
                index = (index + 1) % hashTable.Length;

                // Table full check
                if (index == startIndex)
                {
                    Console.WriteLine("Hash table is full, cannot insert key " + key);
                    return;
                }
            }

            hashTable[index] = key;
            Console.WriteLine($"Inserted key {key} at index {index}");
        }

        // Search in hash table
        public int Search(int key)
        {
            int index = Hash(key);
            int startIndex = index;

            while (hashTable[index] != emptyValue)
            {
                if (hashTable[index] == key)
                    return index;

                index = (index + 1) % tableSize;
                if (index == startIndex)
                    break; // Came back to start
            }

            return -1; // Not found
        }

        // Display hash table
        public void Display()
        {
            Console.WriteLine("Hash Table:");
            for (int i = 0; i < tableSize; i++)
            {
                if (hashTable[i] != emptyValue)
                    Console.WriteLine($"Index {i}: {hashTable[i]}");
                else
                    Console.WriteLine($"Index {i}: Empty");
            }
        }
    }
}
