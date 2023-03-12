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
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Get("key"));
        }


        //Add Method
        [Fact]
        public void HavingAddMethod_ValidParametersAndEmptyBucket_AddsNode()
        {
            hashTable.Add("key", 1);

            Assert.Equal(1, hashTable.Get("key"));
        }
        [Fact]
        public void HavingAddMethod_ValidParametersAndNonEmptyBucket_AddsNodes()
        {
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 1);
            hashTable.Add("key3", 1);
            hashTable.Add("key4", 1);
            hashTable.Add("key5", 1);
            hashTable.Add("key6", 1);
            hashTable.Add("key7", 1);
            hashTable.Add("key8", 1);
            hashTable.Add("key9", 1);
            hashTable.Add("key10", 1);

            Assert.Equal(1, hashTable.Get("key1"));
            Assert.Equal(1, hashTable.Get("key2"));
            Assert.Equal(1, hashTable.Get("key3"));
            Assert.Equal(1, hashTable.Get("key4"));
            Assert.Equal(1, hashTable.Get("key5"));
            Assert.Equal(1, hashTable.Get("key6"));
            Assert.Equal(1, hashTable.Get("key7"));
            Assert.Equal(1, hashTable.Get("key8"));
            Assert.Equal(1, hashTable.Get("key9"));
            Assert.Equal(1, hashTable.Get("key10"));
        }


        //Remove Method
        [Fact]
        public void HavingRemoveMethod_ValidParameter_RemovesNodes()
        {
            hashTable.Remove("key");
            hashTable.Remove("key1");
            hashTable.Remove("key2");
            hashTable.Remove("key3");
            hashTable.Remove("key4");
            hashTable.Remove("key5");
            hashTable.Remove("key6");
            hashTable.Remove("key7");
            hashTable.Remove("key8");
            hashTable.Remove("key9");
            hashTable.Remove("key10");
            Assert.Throws<ArgumentOutOfRangeException>(() => hashTable.Get("key"));

        }


        //Contains Key
        // can't get the mock to work
        [Fact]
        public void HavingContainsKeyMethod_ValidKey_NodeFound()
        {
            var key = "12zdf234";

            mockHashTable
                .Setup(x => x.GetNodeByKey(key))
                .Returns(() => (null,
                          new Node<int>() { Key = key, Value = 1, Next = null}));

            Assert.True(mockHashTable.Object.ContainsKey(key));
        }
        [Fact]
        public void HavingContainsKeyMethod_InvalidKey_NodeNotFound()
        {
            var key = "12zdf234";

            mockHashTable
                .Setup(x => x.GetNodeByKey(key))
                .Returns(() => (null, null));

            Assert.False(mockHashTable.Object.ContainsKey(key));
        }



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
