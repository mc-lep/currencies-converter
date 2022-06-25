using LuccaDevises.Types;

namespace LuccaDevises.Services.UnitTests
{
    public class AmountConverterUnitTests
    {
        [Fact]
        public void Convert_ShouldConvertToTargetCurreny_WhenExchangeRateExplicitlyExists()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "CHF", 1.2053m)
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.Convert(new Amount(550, "EUR"), new Currency("CHF"));

            Assert.Equal(new Amount(662.9150m, "CHF"), result);
        }

        [Fact]
        public void Convert_ShouldConvertToTargetCurreny_WhenInvertExchangeRateExplicitlyExists()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("AUD", "CHF", 0.9661m)
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.Convert(new Amount(662.9150m, "CHF"), new Currency("AUD"));

            Assert.Equal(new Amount(686.1833m, "AUD"), result);
        }
    }
}
