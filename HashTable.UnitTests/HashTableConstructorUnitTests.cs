using Xunit;
using Hashtable;
using System;

namespace HashTable.UnitTests
{
    public class HashTableConstructorUnitTests
    {
        [Fact]
        public void WhenCreatingHashTable_WithValidSize_ObjectIsValid()
        {
            int size = 1;

            HashTable<int> hashTable = new HashTable<int>(size);

            Assert.NotNull(hashTable);
        }

        [Fact]
        public void WhenCreatingHashTable_WithNullSize_ObjectIsValid()
        {
            Assert.Throws<ArgumentNullException>(() => new HashTable<int>(0));
        }
    }
}
