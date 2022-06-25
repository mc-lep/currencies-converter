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

        [Fact]
        public void From_ShouldBeSet_WhenInitializeCalledWithValidSystemTypeValues()
        {
            var instance = new ExchangeRate("EUR", "CHF", 1.2053m);

            Assert.Equal(new Currency("EUR"), instance.From);
        }

        [Fact]
        public void To_ShouldBeSet_WhenInitializeCalledWithValidSystemTypeValues()
        {
            var instance = new ExchangeRate("EUR", "CHF", 1.2053m);

            Assert.Equal(new Currency("CHF"), instance.To);
        }

        [Fact]
        public void Rate_ShouldBeSet_WhenInitializeCalledWithValidSystemTypeValues()
        {
            var instance = new ExchangeRate("EUR", "CHF", 1.2053m);

            Assert.Equal(new Rate(1.2053m), instance.Rate);
        }

        [Fact]
        public void CanConvert_ShouldSayTrue_WhereAllCurrenciesAreExplicitlyKnown()
        {
            var instance = new ExchangeRate("EUR", "CHF", 0.40m);
            var result = instance.CanConvert(new Currency("EUR"), new Currency("CHF"));

            Assert.True(result);
        }

        [Fact]
        public void CanConvert_ShouldSayTrue_WhereAllCurrenciesAreImplicitlyKnown()
        {
            var instance = new ExchangeRate("EUR", "CHF", 0.40m);
            var result = instance.CanConvert(new Currency("CHF"), new Currency("EUR"));

            Assert.True(result);
        }

        [Fact]
        public void CanConvert_ShouldSayTrue_WhereOneCurrencyIsNotKnown()
        {
            var instance = new ExchangeRate("EUR", "CHF", 0.40m);
            var result = instance.CanConvert(new Currency("USD"), new Currency("EUR"));

            Assert.False(result);
        }

        [Fact]
        public void Convert_ShouldConvertAmountFromTo_WhereAmountIsInFromCurrency()
        {
            var instance = new ExchangeRate("EUR", "CHF", 0.40m);
            var result = instance.Convert(new Amount(100m, "EUR"));

            Assert.Equal(new Amount(40, "CHF"), result);
        }

        [Fact]
        public void Convert_ShouldConvertAmountToFrom_WhereAmountIsInToCurrency()
        {
            var instance = new ExchangeRate("EUR", "CHF", 0.40m);
            var result = instance.Convert(new Amount(100m, "CHF"));

            Assert.Equal(new Amount(250m, "EUR"), result);
        }
    }
}
