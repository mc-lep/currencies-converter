namespace LuccaDevises.Types.UnitTests
{
    public class AmountUnitTests
    {
        [Fact]
        public void Value_ShouldBeSet_WithInitializeValue()
        {
            var instance = new Amount(1.234m, "EUR");
            var result = instance.Value;

            Assert.Equal(1.234m, result);
        }

        [Fact]
        public void Value_ShouldBeRoundedTo4Decimals_WhenInitialValueHasMoreThan4Decimals()
        {
            var instance = new Amount(1.23456m, "EUR");
            var result = instance.Value;

            Assert.Equal(1.2346m, result);
        }

        [Fact]
        public void Value_ShouldBeRoundedTo4Decimals_WhenInitialValueHasMoreThan4DecimalsAndACurrency()
        {
            var instance = new Amount(1.23456m, new Currency("EUR"));
            var result = instance.Value;

            Assert.Equal(1.2346m, result);
        }

        [Fact]
        public void Currency_ShouldBeSet_WithInitializeCurrency()
        {
            var instance = new Amount(1.234m, new Currency("EUR"));
            var result = instance.Currency;

            Assert.Equal(new Currency("EUR"), result);
        }

        [Fact]
        public void Currency_ShouldBeSet_WithInitializeCurrencyAsString()
        {
            var instance = new Amount(1.234m, "EUR");
            var result = instance.Currency;

            Assert.Equal(new Currency("EUR"), result);
        }
    }
}
