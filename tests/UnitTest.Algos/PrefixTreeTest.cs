using Prefix;
using Prefix.LeetCode;

namespace UnitTest.Algos
{
    public class PrefixTreeTest
    {
        [Fact]
        public void Insert_ValidWords_WordInserted()
        {
            // Arrange
            var prefixTree = new PrefixTree();

            // Act
            prefixTree.Insert("hello");
            prefixTree.Insert("hellos");
            prefixTree.Insert("hellosa");
            prefixTree.Insert("helloso");
            prefixTree.Insert("bello");

            // Assert
            Assert.True(prefixTree.Search("hello"));
        }

        [Fact]
        public void Insert_NullOrEmptyWord_NothingInserted()
        {

            // Arrange
            var prefixTree = new PrefixTree();

            // Act
            prefixTree.Insert(null);
            prefixTree.Insert("");

            // Assert
            Assert.False(prefixTree.StartsWith("h"));
        }

        [Fact]
        public void Search_ExistingWord_ReturnsTrue()
        {
            // Arrange
            var prefixTree = new PrefixTree();
            prefixTree.Insert("world");

            // Act
            var result = prefixTree.Search("world");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Search_NonExistingWord_ReturnsFalse()
        {
            // Arrange
            var prefixTree = new PrefixTree();
            prefixTree.Insert("apple");

            // Act
            var result = prefixTree.Search("orange");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_ExistingPrefix_ReturnsTrue()
        {
            // Arrange
            var prefixTree = new PrefixTree();
            prefixTree.Insert("apple");

            // Act
            var result = prefixTree.StartsWith("app");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void StartsWith_NonExistingPrefix_ReturnsFalse()
        {
            // Arrange
            var prefixTree = new PrefixTree();
            prefixTree.Insert("apple");

            // Act
            var result = prefixTree.StartsWith("ora");

            // Assert
            Assert.False(result);
        }
    }
}