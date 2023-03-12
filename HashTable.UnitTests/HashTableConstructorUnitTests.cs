using Xunit;
using Hashtable;
using System;

namespace HashTable.UnitTests
{
    public class HashTableConstructorUnitTests
    {
        private int size = 4;

        [Fact]
        public void WhenCreatingHashTable_WithValidSize_ObjectIsValid
            () => Assert.NotNull(new HashTable<int>(size));

        [Fact]
        public void WhenCreatingHashTable_WithNullSize_ObjectIsValid 
            () => Assert.Throws<ArgumentNullException>(() => new HashTable<int>(0));
    }
}
