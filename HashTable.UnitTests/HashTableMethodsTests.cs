using Hashtable;
using Moq;
using System;
using Xunit;

namespace HashTable.UnitTests
{
    public class HashTableUnitTests
    {
        private HashTable<int> hashTable;
        private int size;
        Mock<IHashTable<int>> mockHashTable;

        public HashTableUnitTests()
        {
            size = 4;
            hashTable = new HashTable<int>(size);
            mockHashTable = new Mock<IHashTable<int>>();
        }



        //DisplayAll Method
        [Fact]
        public void HavingDisplayAllMethod_ThrowsNothing
            () => Assert.Null(Record.Exception(() => hashTable.DisplayAll()));

        
        //Get Method
        [Fact]
        public void HavingGetMethod_ValidKey_GetsValue()
        {
            int value = 3;
            hashTable.Add("key", value);

            Assert.Equal(value, hashTable.Get("key"));
            hashTable.Remove("key");
        }
        [Fact]
        public void HavingGetMethod_NodeIsNull_Throws()
        {
            mockHashTable
                .Setup((x) => x.GetNodeByKey("key"))
                .Returns((null, null));

            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Get("key"));
        }


        //Add Method



        //ValidateKey Method
        [Fact]
        public void HavingValidateKeyMethod_ValidKey_ThrowsNothing
            () => Assert.Null(Record.Exception(() => hashTable.ValidateKey("a key")));
        [Fact]
        public void HavingValidateKeyMethod_NullOrEmptyKey_ThrowsNothing
            () 
        {
            Assert.NotNull(Record.Exception(() => hashTable.ValidateKey(" ")));
            Assert.NotNull(Record.Exception(() => hashTable.ValidateKey(null)));
        }
    }
}
