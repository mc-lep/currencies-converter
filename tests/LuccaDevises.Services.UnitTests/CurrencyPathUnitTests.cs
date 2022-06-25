using LuccaDevises.Types;

namespace LuccaDevises.Services.UnitTests
{
    public  class CurrencyPathUnitTests
    {
        [Fact]
        public void GetOrCreateNodeFor_ShouldCreateNewNodeWithCurrency_WhenNodeDoesNotExists()
        {
            var instance = new CurrencyPath();
            var result = instance.GetOrCreateNodeFor(new Currency("EUR"));

            Assert.Equal(new Currency("EUR"), result.Value);
        }

        [Fact]
        public void GetOrCreateNodeFor_ShouldCreateNewNodeWithoutPrevious_WhenNodeDoesNotExists()
        {
            var instance = new CurrencyPath();
            var result = instance.GetOrCreateNodeFor(new Currency("EUR"));

            Assert.Null(result.Previous);
        }

        [Fact]
        public void GetOrCreateNodeFor_ShouldCreateNewNodeWithNoBestPath_WhenNodeDoesNotExists()
        {
            var instance = new CurrencyPath();
            var result = instance.GetOrCreateNodeFor(new Currency("EUR"));

            Assert.False(result.HasBestPath);
        }

        [Fact]
        public void GetOrCreateNodeFor_ShouldNotCreateRootNode_WhenNodeDoesNotExists()
        {
            var instance = new CurrencyPath();
            var result = instance.GetOrCreateNodeFor(new Currency("EUR"));

            Assert.False(result.IsRootNode);
        }

        [Fact]
        public void GetOrCreateNodeFor_ShouldReturnTheNode_WhenNodeExists()
        {
            var instance = new CurrencyPath();
            var firstNode = instance.GetOrCreateNodeFor(new Currency("EUR"));
            var secondNode = instance.GetOrCreateNodeFor(new Currency("JPY"));
            secondNode.Previous = firstNode;

            var result = instance.GetOrCreateNodeFor(new Currency("JPY"));

            Assert.Equal(firstNode, result.Previous);
        }

        [Fact]
        public void GetNodeFor_ShouldReturnTheNode_WhenNodeExists()
        {
            var instance = new CurrencyPath();
            var firstNode = instance.GetOrCreateNodeFor(new Currency("EUR"));
            var result = instance.GetNodeFor(new Currency("EUR"));

            Assert.Equal(firstNode, result);
        }

        [Fact]
        public void GetNodeFor_ShouldReturnEmptyNode_WhenNodeDoeNotExists()
        {
            var instance = new CurrencyPath();
            _ = instance.GetOrCreateNodeFor(new Currency("EUR"));
            var result = instance.GetNodeFor(new Currency("JPY"));

            Assert.Equal(CurrencyPathNode.Empty, result);
        }

        [Fact]
        public void CreateRootNodeFor_ShouldRootNode_WhenCalled()
        {
            var instance = new CurrencyPath();
            var result = instance.CreateRootNodeFor(new Currency("EUR"));

            Assert.True(result.IsRootNode);
        }
    }
}
