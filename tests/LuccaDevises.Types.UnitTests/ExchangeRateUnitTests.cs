namespace LuccaDevises.Types.UnitTests
{
    public class ExchangeRateUnitTests
    {
        [Fact]
        public void From_ShouldBeSet_WhenInitializeCalledWithValidValues()
        {
            var instance = new ExchangeRate(new Currency("EUR"), new Currency("CHF"), new Rate(1.2053m));

            Assert.Equal(new Currency("EUR"), instance.From);
        }

        [Fact]
        public void To_ShouldBeSet_WhenInitializeCalledWithValidValues()
        {
            var instance = new ExchangeRate(new Currency("EUR"), new Currency("CHF"), new Rate(1.2053m));

            Assert.Equal(new Currency("CHF"), instance.To);
        }

        [Fact]
        public void Rate_ShouldBeSet_WhenInitializeCalledWithValidValues()
        {
            var instance = new ExchangeRate(new Currency("EUR"), new Currency("CHF"), new Rate(1.2053m));

            Assert.Equal(new Rate(1.2053m), instance.Rate);
        }
    }
}
