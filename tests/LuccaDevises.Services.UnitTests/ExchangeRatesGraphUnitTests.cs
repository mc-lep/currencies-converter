using LuccaDevises.Types;

namespace LuccaDevises.Services.UnitTests
{
    public class ExchangeRatesGraphUnitTests
    {
        [Fact]
        public void GetExchangeRatesFor_ShouldReturnTheExchangeRate_WhenFromCurrencyIsRequested()
        {
            var exchangeRate = new ExchangeRate[] 
            {
                new ExchangeRate("EUR", "CHF", 1.2053m)
            };

            var instance = new ExchangeRatesGraph(exchangeRate);
            var result = instance.GetExchangeRatesFor(new Currency("EUR")).ToArray()[0];
            Assert.Equal(exchangeRate[0], result);
        }

        [Fact]
        public void GetExchangeRatesFor_ShouldReturnTheExchangeRate_WhenToCurrencyIsRequested()
        {
            var exchangeRate = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "CHF", 1.2053m)
            };

            var instance = new ExchangeRatesGraph(exchangeRate);
            var result = instance.GetExchangeRatesFor(new Currency("CHF")).ToArray()[0];
            Assert.Equal(exchangeRate[0], result);
        }

        [Fact]
        public void GetExchangeRatesFor_ShouldReturnEmptyList_WhenUnknownCurrencyIsRequeted()
        {
            var exchangeRate = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "CHF", 1.2053m)
            };

            var instance = new ExchangeRatesGraph(exchangeRate);
            var result = instance.GetExchangeRatesFor(new Currency("JPY")).ToArray().Length;
            Assert.Equal(0, result);
        }
    }
}
